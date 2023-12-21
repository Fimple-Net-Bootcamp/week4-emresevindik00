using AutoMapper;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Request
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Health, HealthDto>().ReverseMap();
            CreateMap<Activity, ActivityDto>().ReverseMap();
            CreateMap<Pet, PetDto>().ReverseMap();
            CreateMap<Nutrient, NutrientDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
