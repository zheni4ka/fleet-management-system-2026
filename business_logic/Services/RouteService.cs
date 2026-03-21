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
        private readonly IMapper mapper;
        public RouteService(IRepository<Route> routeR, IMapper mapper)
        {
            this.routeR = routeR;
            this.mapper = mapper;
        }

        public void Create(CreateRouteModel routeModel)
        {
            routeR.Insert(mapper.Map<Route>(routeModel));
            routeR.Save();
        }

        public async Task Delete(int id)
        {
            var route = routeR.GetById(id);
            if (route == null)
            {
                throw new Exception("Route not found");
            }
            routeR.Delete(route);
            routeR.Save();
        }

        public async Task<RouteDTO> Get(int id)
        {
            var route = await routeR.GetItemBySpec(new RouteSpecs.ById(id));

            if (route == null) throw new Exception("Route not found");

            return mapper.Map<RouteDTO>(route);
        }

        public IEnumerable<RouteDTO> GetAll()
        {
            var routes = routeR.GetAll();
            return mapper.Map<IEnumerable<RouteDTO>>(routes);
        }
    }
}
