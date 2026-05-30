using AutoMapper;
using business_logic.DTOs;
using business_logic.Entities;
using business_logic.Interfaces;
using business_logic.Specifications;

namespace business_logic.Services
{
    public class RouteService : IRouteService
    {
        private readonly IRepository<Route> routeR;
        private readonly IRepository<Auto> AutoR;
        private readonly IMapper _mapper;
        public RouteService(IRepository<Route> routeR, IRepository<Auto> autoR, IMapper mapper)
        {
            this.routeR = routeR;
            this.AutoR = autoR;
            this._mapper = mapper;
        }

        public void Create(CreateRouteModel routeModel)
        {
            var auto = AutoR.GetById(routeModel.AutoId);
            if (auto == null)
            {
                throw new KeyNotFoundException("Auto not found");
            }

            if (auto.Status == AutoStatus.UnderMaintenance)
            {
                throw new InvalidOperationException("Unable to create route: vehicle is currently under maintenance.");
            }

            if (auto.Status == AutoStatus.InService)
            {
                throw new InvalidOperationException("Unable to create route: vehicle is already in a route.");
            }

            var route = _mapper.Map<Route>(routeModel);
            routeR.Insert(route);
            routeR.Save();
        }

        public async Task Delete(int id)
        {
            var route =  routeR.GetById(id);
            if (route == null)
            {
                throw new KeyNotFoundException("Route not found");
            }

            // Якщо видаляємо активний рейс, звільняємо машину
            if (route.Status == RouteStatus.InProgress)
            {
                var auto =  AutoR.GetById(route.AutoId);
                if (auto != null)
                {
                    auto.Status = AutoStatus.Available;
                     AutoR.Update(auto);
                     AutoR.Save();
                }
            }

            routeR.Delete(id);
        }

        public async Task<RouteDTO> Get(int id)
        {
            var route = await routeR.GetItemBySpec(new RouteSpecs.ById(id));

            if (route == null) throw new Exception("Route not found");

            return _mapper.Map<RouteDTO>(route);
        }

        public IEnumerable<RouteDTO> GetAll()
        {
            var routes = routeR.GetAll();
            return _mapper.Map<IEnumerable<RouteDTO>>(routes);
        }

        public async Task Update(EditRouteModel model)
        {
            var route = routeR.GetById(model.Id);
            if (route == null)
            {
                throw new KeyNotFoundException("Route not found");
            }

            var oldStatus = route.Status;
            _mapper.Map(model, route);

            if (oldStatus != route.Status)
            {
                var auto = AutoR.GetById(route.AutoId);
                if (auto != null)
                {
                    if (route.Status == RouteStatus.InProgress)
                    {
                        auto.Status = AutoStatus.InService;
                        AutoR.Update(auto);
                        AutoR.Save();
                    }
                    else if (route.Status == RouteStatus.Completed || route.Status == RouteStatus.Cancelled)
                    {
                        auto.Status = AutoStatus.Available;
                        AutoR.Update(auto);
                        AutoR.Save();
                    }
                }
            }

            routeR.Update(route);
            routeR.Save();
        }
    }
}
