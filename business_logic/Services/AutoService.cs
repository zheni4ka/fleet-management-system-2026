using AutoMapper;
using business_logic.DTOs;
using business_logic.Entities;
using business_logic.Interfaces;
using business_logic.Specifications;

namespace business_logic.Services
{
    public class AutoService : IAutoService
    {
        private readonly IRepository<Auto> _autoR;
        private readonly IAuditLogService _auditLogService;
        private readonly IMapper _mapper;
        public AutoService(IRepository<Auto> autoR, IMapper mapper)
        {
            this._autoR = autoR;
            this._mapper = mapper;
        }

        public void Create(CreateAutoModel autoModel)
        {
            _autoR.Insert(_mapper.Map<Auto>(autoModel));
            _autoR.Save();
        }

        public async Task Delete(int id)
        {
            var auto = _autoR.GetById(id);

            if (auto == null)
            {
                throw new Exception("Auto not found");
            }
            _autoR.Delete(auto);
            _autoR.Save();
        }

        public async Task Edit(EditAutoModel model)
        {
            var auto = _autoR.GetById(model.Id);
            if (auto == null) throw new KeyNotFoundException("Auto not found");
            _mapper.Map(model, auto);
            _autoR.Update(auto);
            _autoR.Save();
        }

        public async Task<AutoDTO> Get(int id)
        {
            var auto = await _autoR.GetItemBySpec(new AutoSpecs.ById(id));

            if (auto == null) throw new Exception("Auto not found");

            return _mapper.Map<AutoDTO>(auto);
        }

        public IEnumerable<AutoDTO> GetAll()
        {
            var autos = _autoR.GetAll();
            return _mapper.Map<IEnumerable<AutoDTO>>(autos);
        }

        public async Task UpdateStatus(int autoId, AutoStatus newStatus)
        {
            var auto = _autoR.GetById(autoId);
            if(auto == null)
            {
                throw new Exception("Auto not found");
            }
            auto.Status = newStatus;

            _autoR.Update(auto);
            _autoR.Save();
        }
    }
}
