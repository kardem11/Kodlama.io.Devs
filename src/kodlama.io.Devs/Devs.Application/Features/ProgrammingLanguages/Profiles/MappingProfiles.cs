using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Devs.Application.Features.ProgrammingLanguages.Dtos;
using Devs.Application.Features.ProgrammingLanguages.Models;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguageListModel, IPaginate<ProgrammingLanguage>>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();

            CreateMap<ProgrammingLanguageGetByIdDto, ProgrammingLanguage>().ReverseMap();
            CreateMap<DeletedProgrammingLanguageDto, ProgrammingLanguage>().ReverseMap();

            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();
            CreateMap<DeletedProgrammingLanguageDto, ProgrammingLanguage>().ReverseMap();

            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();
            CreateMap<UpdatedProgrammingLanguageDto, ProgrammingLanguage>().ReverseMap();


        }
    }
}
