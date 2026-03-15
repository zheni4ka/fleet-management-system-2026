using AutoMapper;
using business_logic.DTOs;
using business_logic.Entities;
using business_logic.Interfaces;
using business_logic.Specifications;

namespace business_logic.Services
{
    public class DriverService : IDriverService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Driver> driverR;
        public DriverService(IRepository<Driver> driverRs, IMapper mapper)
        {
            this.driverR = driverRs;
            this.mapper = mapper;
        }

        public void Create(CreateDriverModel driverModel)
        {
            driverR.Insert(mapper.Map<Driver>(driverModel));
            driverR.Save();
        }

        public Task Delete(int id)
        {
            var driver = Get(id);
            if (driver == null)
            {
                throw new Exception("Driver not found");
            }
            driverR.Delete(driver);
            return Task.CompletedTask;
        }
        public IEnumerable<DriverDTO> GetAll()
        {
            return mapper.Map<List<DriverDTO>>(driverR.GetAll());
        }
        public async Task<DriverDTO> Get(int id)
        {
            var driver = await driverR.GetItemBySpec(new DriverSpecs.ById(id));

            if (driver == null) throw new Exception("Driver not found");
           
            return mapper.Map<DriverDTO>(driver);
        }
    }
}
