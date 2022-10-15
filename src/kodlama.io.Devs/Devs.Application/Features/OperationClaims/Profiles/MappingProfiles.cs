using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Devs.Application.Features.OperationClaims.Dtos;
using Devs.Application.Features.OperationClaims.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.OperationClaims.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
            CreateMap<OperationClaimListModel, OperationClaimListDto>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();

        }
    }
}
