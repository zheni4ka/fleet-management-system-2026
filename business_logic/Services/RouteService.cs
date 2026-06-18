using AutoMapper;
using business_logic.DTOs;
using business_logic.DTOs.AuditLogs;
using business_logic.Entities;
using business_logic.Interfaces;
using business_logic.Specifications;
using System.Globalization;

namespace business_logic.Services
{
    public class RouteService : IRouteService
    {
        private readonly IRepository<Route> routeR;
        private readonly IRepository<Auto> AutoR;
        private readonly IRepository<AuditLog> AuditLogR;
        private readonly IMapper _mapper;

        public RouteService(IRepository<Route> routeR, IRepository<Auto> autoR, IMapper mapper)
        {
            this.routeR = routeR;
            this.AutoR = autoR;
            this._mapper = mapper;
        }

        private bool IsAutoAvailable(int autoId, DateTime departure, DateTime arrival, int? excludeRouteId = null)
        {
            var routes = routeR.GetAll().Where(r => r.AutoId == autoId && r.Status != RouteStatus.Cancelled && r.Status != RouteStatus.Completed);
        
            if (excludeRouteId.HasValue) routes = routes.Where(r => r.Id != excludeRouteId.Value);
            return !routes.Any(r => r.DepartureTime < arrival && r.ArrivalTime > departure);
        }

        private bool IsDriverAvailable(int driverId, DateTime departure, DateTime arrival, int? excludeRouteId = null)
        {
            var routes = routeR.GetAll().Where(r => r.DriverId == driverId && r.Status != RouteStatus.Cancelled && r.Status != RouteStatus.Completed);

            if (excludeRouteId.HasValue) routes = routes.Where(r => r.Id != excludeRouteId.Value);
            return !routes.Any(r => r.DepartureTime < arrival && r.ArrivalTime > departure);
        }

        public void Create(CreateRouteModel routeModel, string dispatcherId)
        {
            var auto = AutoR.GetById(routeModel.AutoId);
            if (auto == null) throw new KeyNotFoundException("Auto not found");
            if (auto.Status == AutoStatus.UnderMaintenance) throw new InvalidOperationException("Автомобіль на ремонті.");

            if (!IsAutoAvailable(routeModel.AutoId, routeModel.DepartureTime, routeModel.ArrivalTime))
                throw new InvalidOperationException("Автомобіль вже зайнятий на іншому рейсі у цей час.");

            if (!IsDriverAvailable(routeModel.DriverId, routeModel.DepartureTime, routeModel.ArrivalTime))
                throw new InvalidOperationException("Водій вже зайнятий на іншому рейсі у цей час.");


            var route = _mapper.Map<Route>(routeModel);
            routeR.Insert(route);
            routeR.Save();

            if (route.Status == RouteStatus.InProgress)
            {
                auto.Status = AutoStatus.InService;
                AutoR.Update(auto);
                AutoR.Save();
            }
        }

        public async Task Update(EditRouteModel model)
        {
            var route = routeR.GetById(model.Id);
            if (route == null) throw new KeyNotFoundException("Route not found");

            if (!IsAutoAvailable(model.AutoId, route.DepartureTime, route.ArrivalTime, model.Id))
                throw new InvalidOperationException("New auto is busy at this time");

            if (!IsDriverAvailable(model.DriverId, route.DepartureTime, route.ArrivalTime, model.Id))
                throw new InvalidOperationException("New driver is busy at this time");

            int oldAutoId = route.AutoId; 
            var oldStatus = route.Status;

            _mapper.Map(model, route);

            if (oldAutoId != route.AutoId)
            {
                var oldAuto = AutoR.GetById(oldAutoId);
                if (oldAuto != null && oldStatus == RouteStatus.InProgress)
                {
                    oldAuto.Status = AutoStatus.Available; 
                    AutoR.Update(oldAuto);
                }
            }

            var currentAuto = AutoR.GetById(route.AutoId);
            if (currentAuto != null)
            {
                if (route.Status == RouteStatus.InProgress) currentAuto.Status = AutoStatus.InService;
                else if (route.Status == RouteStatus.Completed || route.Status == RouteStatus.Cancelled) currentAuto.Status = AutoStatus.Available;
                AutoR.Update(currentAuto);
            }

            routeR.Update(route);
            routeR.Save();
            AutoR.Save(); 
        }

        public async Task Delete(int id, string dispatcherId)
        {
            var route = routeR.GetById(id);
            if (route == null) throw new KeyNotFoundException("Route not found");

            if (route.Status == RouteStatus.InProgress)
            {
                var auto = AutoR.GetById(route.AutoId);
                if (auto != null)
                {
                    auto.Status = AutoStatus.Available;
                    AutoR.Update(auto);
                    AutoR.Save();
                }
            }



            routeR.Delete(id);
            routeR.Save();
        }

        public async Task<RouteDTO> Get(int id)
        {
            var route = await routeR.GetItemBySpec(new RouteSpecs.ById(id));
            if (route == null) throw new Exception("Route not found");
            return _mapper.Map<RouteDTO>(route);
        }

        public IEnumerable<RouteDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<RouteDTO>>(routeR.GetAll());
        }
    }
}