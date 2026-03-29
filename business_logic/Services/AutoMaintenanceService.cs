using AutoMapper;
using business_logic.DTOs;
using business_logic.Entities;
using business_logic.Interfaces;
using business_logic.Specifications;

namespace business_logic.Services
{
    public class AutoMaintenanceService : IAutoMaintenanceService
    {
        private readonly IRepository<AutoMaintenance> _amR;
        private readonly IMapper _mapper;

        public AutoMaintenanceService(IRepository<AutoMaintenance> amR, IMapper mapper)
        {
            _amR = amR;
            _mapper = mapper;
        }

        public void Create(CreateAutoMaintenanceModel driverModel)
        {
            _amR.Insert(_mapper.Map<AutoMaintenance>(driverModel));
            _amR.Save();
        }

        public async Task<IEnumerable<AutoMaintenanceDTO>> GetByAutoId(int id)
        {
            var items = await _amR.GetListBySpec(new AutoMaintenanceSpecs.ByAutoId(id));

            if (items == null) { throw new Exception("item not found"); }

            return _mapper.Map<List<AutoMaintenanceDTO>>(items);
        }

        public async Task<AutoMaintenanceDTO> Get(int id)
        {
            var item = await _amR.GetItemBySpec(new AutoMaintenanceSpecs.ById(id));

            if (item == null) { throw new Exception("item not found"); }

            return _mapper.Map<AutoMaintenanceDTO>(item);
        }

        public IEnumerable<AutoMaintenanceDTO> GetAll() { return _mapper.Map<IEnumerable<AutoMaintenanceDTO>>(_amR.GetAll()); }

    }
}
