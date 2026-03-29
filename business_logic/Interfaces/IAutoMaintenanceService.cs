using business_logic.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic.Interfaces
{
    public interface IAutoMaintenanceService
    {
        public void Create(CreateAutoMaintenanceModel driverModel);
        public Task<AutoMaintenanceDTO> Get(int id);
        public IEnumerable<AutoMaintenanceDTO> GetAll();
        public Task<IEnumerable<AutoMaintenanceDTO>> GetByAutoId(int id);
    }
}
