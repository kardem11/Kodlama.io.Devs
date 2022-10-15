using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Devs.Application.Features.OperationClaims.Models;
using Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.OperationClaims.Queries
{
    public class GetListOperationClaimQuery : IRequest<OperationClaimListModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles { get; } = { "Admin" };

        public class GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery, OperationClaimListModel>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
                => (_operationClaimRepository, _mapper) = (operationClaimRepository, mapper);

            public async Task<OperationClaimListModel> Handle(GetListOperationClaimQuery request,
                CancellationToken cancellationToken)
            {
                IPaginate<OperationClaim> operationClaims =
                    await _operationClaimRepository.GetListAsync(index: request.PageRequest.Page,
                        size: request.PageRequest.PageSize);

                OperationClaimListModel operationClaimListModel = _mapper.Map<OperationClaimListModel>(operationClaims);

                return operationClaimListModel;
            }
        }
    
    }
}
