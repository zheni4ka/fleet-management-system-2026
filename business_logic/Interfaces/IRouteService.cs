using business_logic.DTOs;

namespace business_logic.Interfaces
{
    public interface IRouteService
    {
        public void Create(CreateRouteModel routeModel, string dispatcherId);
        public Task<RouteDTO> Get(int id);
        public IEnumerable<RouteDTO> GetAll();
        public Task Delete(int id, string dispatcherId);
        public Task Update(EditRouteModel model);
    }
}
