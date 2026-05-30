using business_logic.DTOs;

namespace business_logic.Interfaces
{
    public interface IRouteService
    {
        public void Create(CreateRouteModel routeModel);
        public Task<RouteDTO> Get(int id);
        public IEnumerable<RouteDTO> GetAll();
        public Task Delete(int id);
        public Task Update(EditRouteModel model);
    }
}
