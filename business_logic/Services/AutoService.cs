using AutoMapper;
using business_logic.DTOs;
using business_logic.Entities;
using business_logic.Interfaces;
using business_logic.Specifications;

namespace business_logic.Services
{
    public class AutoService : IAutoService
    {
        private readonly IRepository<Auto> autoR;
        private readonly IMapper _mapper;
        public AutoService(IRepository<Auto> autoR, IMapper mapper)
        {
            this.autoR = autoR;
            this._mapper = mapper;
        }

        public void Create(CreateAutoModel autoModel)
        {
            autoR.Insert(_mapper.Map<Auto>(autoModel));
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
            autoR.Update(_mapper.Map<Auto>(model));
            autoR.Save();
        }

        public async Task<AutoDTO> Get(int id)
        {
            var auto = await autoR.GetItemBySpec(new AutoSpecs.ById(id));

            if (auto == null) throw new Exception("Auto not found");

            return _mapper.Map<AutoDTO>(auto);
        }

        public IEnumerable<AutoDTO> GetAll()
        {
            var autos = autoR.GetAll();
            return _mapper.Map<IEnumerable<AutoDTO>>(autos);
        }

        public async Task UpdateStatusAsync(int autoId, AutoStatus newStatus)
        {
            var auto = autoR.GetById(autoId);
            if(auto == null)
            {
                throw new Exception("Auto not found");
            }
            auto.Status = newStatus;

            autoR.Update(auto);
            autoR.Save();
        }
    }
}
