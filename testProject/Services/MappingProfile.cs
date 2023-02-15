using AutoMapper;
using Common.DTOs;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
			CreateMap<Person, PersonDTO>().ReverseMap();
			CreateMap<Child, ChildDTO>().ReverseMap();
			CreateMap<Gender, GenderDTO>().ReverseMap();
			CreateMap<HealthFund, HealthFundDTO>().ReverseMap();
		}
    }
}
