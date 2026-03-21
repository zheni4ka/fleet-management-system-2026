using AutoMapper;
using business_logic.DTOs;
using business_logic.Entities;
using business_logic.Interfaces;
using business_logic.Specifications;
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
            autoR.Insert(mapper.Map<Auto>(autoModel));
            autoR.Save();
        }

        public async Task Delete(int id)
        {
            var auto = autoR.GetById(id);
            if (auto == null)
            {
                throw new Exception("Auto not found");
            }
            autoR.Delete(auto);
            autoR.Save();
        }

        public async Task Edit(EditAutoModel model)
        {
            autoR.Update(mapper.Map<Auto>(model));
            autoR.Save();
        }

        public async Task<AutoDTO> Get(int id)
        {
            var auto = await autoR.GetItemBySpec(new AutoSpecs.ById(id));

            if (auto == null) throw new Exception("Auto not found");

            return mapper.Map<AutoDTO>(auto);
        }

        public IEnumerable<AutoDTO> GetAll()
        {
            var autos = autoR.GetAll();
            return mapper.Map<IEnumerable<AutoDTO>>(autos);
        }
    }
}
