using AutoMapper;
using business_logic.DTOs;
using business_logic.Entities;
using business_logic.Interfaces;
using business_logic.Specifications;

namespace business_logic.Services
{
    public class AutoMaintenanceService : IAutoMaintenanceService
    {
        private readonly IRepository<AutoMaintenance> _amR;
        private readonly IRepository<Auto> _autoR;
        private readonly IRepository<Route> _routeR;
        private readonly IMapper _mapper;

        public AutoMaintenanceService(IRepository<AutoMaintenance> amR, IRepository<Auto> autoR, IMapper mapper, IRepository<Route> rs)
        {
            _amR = amR;
            _autoR = autoR;
            _mapper = mapper;
            _routeR = rs;
        }

        public async Task Update(EditAutoMaintenanceModel model)
        {
            var service = _amR.GetById(model.Id);
            if (service == null)
            {
                throw new KeyNotFoundException("Record not found");
            }

            _mapper.Map(model, service);
            _amR.Update(service);
            _amR.Save();

            if (model.IsCompleted)
            {
                var auto = _autoR.GetById(service.AutoId);
                if (auto != null && auto.Status == AutoStatus.UnderMaintenance)
                {
                    auto.Status = AutoStatus.Available;
                    _autoR.Update(auto);
                    _autoR.Save();
                }
            }
        }

        public void Create(CreateAutoMaintenanceModel model)
        {
            var auto = _autoR.GetById(model.AutoId);
            if (auto == null)
            {
                throw new KeyNotFoundException("Автомобіль не знайдено");
            }
            var affectedRoutes = _routeR.GetAll()
                .Where(r => r.AutoId == model.AutoId &&
                           (r.Status == RouteStatus.Planned || r.Status == RouteStatus.InProgress) &&
                           r.DepartureTime >= model.ServiceDate)
                .ToList();

            foreach (var route in affectedRoutes)
            {
                route.Status = RouteStatus.Cancelled;
                _routeR.Update(route);
            }

            if (affectedRoutes.Any())
            {
                _routeR.Save();
            }
            var service = _mapper.Map<AutoMaintenance>(model);
            _amR.Insert(service);
            _amR.Save();

            auto.Status = AutoStatus.UnderMaintenance;
            _autoR.Update(auto);
            _autoR.Save();

            _mapper.Map<AutoMaintenanceDTO>(service);
        }

        public async Task Delete(int id)
        {
            var service = _amR.GetById(id);
            if (service == null)
            {
                throw new KeyNotFoundException("Record not found");
            }

            var auto = _autoR.GetById(service.AutoId);
            if (auto != null)
            {
                auto.Status = AutoStatus.Available;
                _autoR.Update(auto);
                _autoR.Save();
            }

            _amR.Delete(id);
            _amR.Save();
        }

        public async Task<IEnumerable<AutoMaintenanceDTO>> GetByAutoId(int id)
        {
            var items = await _amR.GetListBySpec(new AutoMaintenanceSpecs.ByAutoId(id));

            if (items == null) { throw new Exception("item not found"); }

            return _mapper.Map<List<AutoMaintenanceDTO>>(items);
        }

        public async Task<AutoMaintenanceDTO> Get(int id)
        {
            var item = await _amR.GetItemBySpec(new AutoMaintenanceSpecs.ById(id));

            if (item == null) { throw new Exception("item not found"); }

            return _mapper.Map<AutoMaintenanceDTO>(item);
        }

        public IEnumerable<AutoMaintenanceDTO> GetAll() { return _mapper.Map<IEnumerable<AutoMaintenanceDTO>>(_amR.GetAll()); }

    

    }
}
