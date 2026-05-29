using AutoMapper;
using business_logic.Entities;
using business_logic.DTOs;

namespace business_logic
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Driver, DriverDTO>().ReverseMap();
            CreateMap<Driver, CreateDriverModel>().ReverseMap();
            CreateMap<Driver, EditDriverModel>().ReverseMap();

            CreateMap<Auto, AutoDTO>().ReverseMap();
            CreateMap<Auto, CreateAutoModel>().ReverseMap();
            CreateMap<Auto, EditAutoModel>().ReverseMap();

            CreateMap<Route, RouteDTO>().ReverseMap();
            CreateMap<Route, CreateRouteModel>().ReverseMap();
            CreateMap<Location, LocationDTO>().ReverseMap();
            CreateMap<Location, CreateLocationModel>().ReverseMap();
            CreateMap<AutoMaintenance, AutoMaintenanceDTO>().ReverseMap();
            CreateMap<AutoMaintenance, CreateAutoMaintenanceModel>().ReverseMap();
        }
    }
}
