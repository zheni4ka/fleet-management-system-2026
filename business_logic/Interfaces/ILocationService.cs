using business_logic.DTOs;

namespace business_logic.Interfaces
{
    public interface ILocationService
    {
        public void Create(CreateLocationModel model);
        public IEnumerable<LocationDTO> GetAll();
        public Task<LocationDTO> Get(int id);
        public Task Delete(int id);
    }
}
