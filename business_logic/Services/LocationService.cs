using AutoMapper;
using business_logic.DTOs;
using business_logic.Entities;
using business_logic.Interfaces;

namespace business_logic.Services
{
    public class LocationService : ILocationService
    {
        private readonly IRepository<Location> _repo;
        private readonly IRepository<Route> _routeRepo; 
        private readonly IMapper _mapper;

        public LocationService(IRepository<Location> repo, IRepository<Route> routeRepo, IMapper mapper)
        {
            _repo = repo;
            _routeRepo = routeRepo; 
            _mapper = mapper;
        }

        public void Create(CreateLocationModel model)
        {
            _repo.Insert(_mapper.Map<Location>(model));
            _repo.Save();
        }

        public async Task Delete(int id)
        {
            var loc = _repo.GetById(id);
            if (loc == null) throw new Exception("Location not found");

            var isUsedInRoutes = _routeRepo.GetAll()
                .Any(r => r.StartLocationId == id || r.DestinationLocationId == id);

            if (isUsedInRoutes)
            {
                throw new InvalidOperationException("Unable to delete location");
            }

            _repo.Delete(id);
            _repo.Save();
        }

        public IEnumerable<LocationDTO> GetAll() => _mapper.Map<IEnumerable<LocationDTO>>(_repo.GetAll());

        public async Task<LocationDTO> Get(int id)
        {
            var loc = _repo.GetById(id);
            if (loc == null) throw new Exception("Location not found");
            return _mapper.Map<LocationDTO>(loc);
        }
    }
}