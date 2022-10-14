using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.Technologies.Commands.CreateTechnology;
using Devs.Application.Features.Technologies.Commands.DeleteTechnology;
using Devs.Application.Features.Technologies.Commands.UpdateTechnology;
using Devs.Application.Features.Technologies.Dtos;
using Devs.Application.Features.Technologies.Models;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Technologies.Profiles
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {

            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();

            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();
            CreateMap<Technology, CreatedTechnologyDto>().ReverseMap();

            CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();
            CreateMap<Technology, UpdatedTechnologyDto>().ReverseMap();

            CreateMap<Technology, DeleteTechnologyCommand>().ReverseMap();
            CreateMap<Technology, DeletedTechnologyDto>().ReverseMap();
            CreateMap<Technology, TechnologyListDto>().ForMember(t => t.ProgrammingLanguageName, opt => opt.MapFrom(p => p.ProgrammingLanguage.Name)).ReverseMap();


        }
    }
}
