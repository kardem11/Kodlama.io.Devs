using AutoMapper;
using Core.Security.Entities;
using Devs.Application.Features.Users.Commands.LoginCommand;
using Devs.Application.Features.Users.Commands.RegisterCommand;
using Devs.Application.Features.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
          
            CreateMap<User, RegisteredUserDto>().ReverseMap();
            CreateMap<User, RegisterUserCommand>().ReverseMap();

            CreateMap<User, LoginUserCommand>().ReverseMap();
        }
    }
}
