using AutoMapper;
using business_logic.Entities;
using business_logic.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using business_logic.DTOs.Driver;

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
        }
    }
}
