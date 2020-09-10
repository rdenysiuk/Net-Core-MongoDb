using AutoMapper;
using CarBL.Models;
using CarDL;

namespace CarBL.Mapping
{
    public class DtoToEntity : Profile
    {
        public DtoToEntity()
        {
            CreateMap<Car, CarModel>().ReverseMap();
        }
    }
}
