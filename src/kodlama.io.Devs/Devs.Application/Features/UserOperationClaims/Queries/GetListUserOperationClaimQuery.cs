using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Devs.Application.Features.UserOperationClaims.Dtos;
using Devs.Application.Features.UserOperationClaims.Models;
using Devs.Application.Features.UserOperationClaims.Rules;
using Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.UserOperationClaims.Queries
{
    public class GetListUserOperationClaimQuery : IRequest<UserOperationClaimListModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles { get; } = { "Admin" };

        class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListUserOperationClaimQuery,
            UserOperationClaimListModel>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public GetListUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository)
                => _userOperationClaimRepository = userOperationClaimRepository;

            public async Task<UserOperationClaimListModel> Handle(GetListUserOperationClaimQuery request,
                CancellationToken cancellationToken)
            {
                var result = await _userOperationClaimRepository.GetListAsync(
                    include: m => m.Include(u => u.OperationClaim)
                        .Include(u => u.User),
                    index:
                    request.PageRequest.Page,
                    size:
                    request.PageRequest.PageSize);

                UserOperationClaimListModel getListUserOperationClaimModel = new()
                {
                    Count = result.Count,
                    Index = result.Index,
                    Pages = result.Pages,
                    Size = result.Size,
                    HasNext = result.HasNext,
                    HasPrevious = result.HasPrevious,
                    Items = result.Items.Select(x => new UserOperationClaimListDto
                    {
                        Id = x.Id,
                        UserId = x.UserId,
                        OperationClaimId = x.OperationClaimId,
                        Name = x.OperationClaim.Name,
                        FirstName = x.User.FirstName,
                        LastName = x.User.LastName
                    }).ToArray()
                };

                return getListUserOperationClaimModel;
            }
        }
    }
}
