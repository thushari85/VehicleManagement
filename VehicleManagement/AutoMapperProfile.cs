using AutoMapper;
using VehicleManagement.Data;
using VehicleManagement.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleManagement
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CarDto, Car>().ReverseMap();
        }
    }
}
