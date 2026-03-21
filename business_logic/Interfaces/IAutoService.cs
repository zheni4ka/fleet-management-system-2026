using business_logic.DTOs;

namespace business_logic.Interfaces
{
    public interface IAutoService
    {
        public void Create(CreateAutoModel driverModel);
        public Task<AutoDTO> Get(int id);
        public IEnumerable<AutoDTO> GetAll();
        public Task Delete(int id);
        public Task Edit(EditAutoModel model);

    }
}
