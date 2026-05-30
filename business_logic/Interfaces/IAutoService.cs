using business_logic.DTOs;
using business_logic.Entities;

namespace business_logic.Interfaces
{
    public interface IAutoService
    {
        public IEnumerable<AutoDTO> GetAll();
        public Task<AutoDTO> Get(int id);
        public void Create(CreateAutoModel driverModel);
        public Task Delete(int id);
        public Task Edit(EditAutoModel model);

        public Task UpdateStatus(int autoId, AutoStatus newStatus);
    }
}
