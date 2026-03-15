using AutoMapper;
using business_logic.DTOs;
using business_logic.Entities;
using business_logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic.Services
{
    public class AutoService : IAutoService
    {
        private readonly IRepository<Auto> autoR;
        private readonly IMapper mapper;
        public AutoService(IRepository<Auto> autoR, IMapper mapper)
        {
            this.autoR = autoR;
            this.mapper = mapper;
        }

        public void Create(CreateAutoModel autoModel)
        {
            var auto = mapper.Map<Auto>(autoModel);
            autoR.Insert(auto);
        }

        public Task Delete(int id)
        {
            var auto = autoR.GetById(id);
            if (auto == null)
            {
                throw new Exception("Auto not found");
            }
            autoR.Delete(auto);
            return Task.CompletedTask;
        }


        public Task<AutoDTO> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
