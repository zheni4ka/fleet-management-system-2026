using AutoMapper;
using business_logic.DTOs;
using business_logic.Entities;
using business_logic.Interfaces;

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
            var driver = driverR.GetById(id);
            if (driver == null)
            {
                throw new Exception("Driver not found");
            }
            driverR.Delete(driver);
            return Task.CompletedTask;
        }
        public IEnumerable<DriverDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Driver>, IEnumerable<DriverDTO>>(driverR.GetAll());
        }
        public Task<DriverDTO> Get(int id)
        {
            var driver = driverR.GetById(id);
            if (driver == null)
            {
                throw new Exception("Driver not found");
            }
            return Task.FromResult(mapper.Map<DriverDTO>(driver));
        }
        public Task<IEnumerable<DriverDTO>> Get(IEnumerable<int> ids)
        {
            var drivers = driverR.GetAll().Where(d => ids.Contains(d.Id));
            return Task.FromResult(mapper.Map<IEnumerable<Driver>, IEnumerable<DriverDTO>>(drivers));
        }
    }
}
