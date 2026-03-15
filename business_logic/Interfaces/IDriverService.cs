using business_logic.DTOs;

namespace business_logic.Interfaces
{
    public interface IDriverService
    {
        public void Create(CreateDriverModel driverModel);
        public Task<DriverDTO> Get(int id);
        public IEnumerable<DriverDTO> GetAll();
        public Task Delete(int id);
        //public Task Edit(EditAutoModel model);
    }
}
