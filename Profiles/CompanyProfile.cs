using AutoMapper;
using farma_api.Dtos;
using farma_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farma_api.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyReadDto>();
            CreateMap<CompanyCreateUpdateDto, Company>();
            CreateMap<Company, CompanyWithoutListsDto>();
            CreateMap<Company, CompanyCreateUpdateDto>();
        }
    }
}
