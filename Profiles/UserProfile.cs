using AutoMapper;
using farma_api.Dtos;
using farma_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateUpdateDto, Company>().ReverseMap();
        }
            
    }
}
