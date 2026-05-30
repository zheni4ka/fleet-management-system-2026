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
        private readonly IMapper _mapper;

        public AutoMaintenanceService(IRepository<AutoMaintenance> amR, IRepository<Auto> autoR, IMapper mapper)
        {
            _amR = amR;
            _autoR = autoR;
            _mapper = mapper;
        }

        public async Task Update(AutoMaintenanceDTO model)
        {
            var service = _amR.GetById(model.Id);
            if (service == null)
            {
                throw new KeyNotFoundException("Запис про технічне обслуговування не знайдено");
            }
            _mapper.Map(model, service);
             _amR.Update(service);
             _amR.Save();
        }

        public void Create(CreateAutoMaintenanceModel driverModel)
        {
            var auto =  _autoR.GetById(driverModel.AutoId);
            if (auto != null && auto.Status == AutoStatus.InService)
            {
                throw new InvalidOperationException("Автомобіль зараз у рейсі й не може бути відправлений на ремонт!");
            }

            var service = _mapper.Map<AutoMaintenance>(driverModel);
             _amR.Insert(service);
             _amR.Save();

            if (auto != null)
            {
                auto.Status = AutoStatus.UnderMaintenance;
                _autoR.Update(auto);
                _autoR.Save();
            }

             _mapper.Map<AutoMaintenanceDTO>(service);
        }

        public async Task DeleteAsync(int id)
        {
            var service =  _amR.GetById(id);
            if (service == null)
            {
                throw new KeyNotFoundException("Запис про технічне обслуговування не знайдено");
            }

            var auto =  _autoR.GetById(service.AutoId);
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

        public Task Update(EditAutoMaintenanceModel model)
        {
            throw new NotImplementedException();
        }
    }
}
