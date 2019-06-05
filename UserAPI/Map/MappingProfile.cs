using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;

namespace UserAPI.Map
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserModel>();
        }
    }
}
