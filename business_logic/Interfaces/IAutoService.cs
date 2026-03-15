using business_logic.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic.Interfaces
{
    public interface IAutoService
    {
        public void Create(CreateAutoModel autoModel);
        public Task<AutoDTO> Get(int id);
        public Task Delete(int id);

    }
}
