using AutoMapper;
using CarBL.Models;
using CarDL.Entities;

namespace CarDL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarModel>().ReverseMap();
        }
    }
}
