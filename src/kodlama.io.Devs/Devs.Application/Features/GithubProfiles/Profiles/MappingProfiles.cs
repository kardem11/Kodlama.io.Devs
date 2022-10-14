using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.GithubProfiles.Commands;
using Devs.Application.Features.GithubProfiles.Dtos;
using Devs.Application.Features.GithubProfiles.Models;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.GithubProfiles.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<GithubProfile, CreateGithub>().ReverseMap();
            CreateMap<GithubProfile, CreatedGithubDto>().ReverseMap();

            CreateMap<GithubProfile, UpdateGithub>().ReverseMap();
            CreateMap<GithubProfile, UpdatedGithubDto>().ReverseMap();

            CreateMap<GithubProfile, DeleteGithub>().ReverseMap();
            CreateMap<GithubProfile, DeletedGithubDto>().ReverseMap();

            CreateMap<GithubListModel, IPaginate<GithubProfile>>().ReverseMap();
            CreateMap<GithubProfile, GithubListDto>().ReverseMap();


        }
    }
}
