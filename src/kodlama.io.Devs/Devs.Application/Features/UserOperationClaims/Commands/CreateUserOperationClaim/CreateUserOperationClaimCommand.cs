using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Devs.Application.Features.UserOperationClaims.Dtos;
using Devs.Application.Features.UserOperationClaims.Rules;
using Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>, ISecuredRequest
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public string[] Roles => new[] { "Admin" };

        public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreatedUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

            public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            }

            public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _userOperationClaimBusinessRules.UserOperationClaimCanNotBeDuplicatedWhenInsertedOrUpdated(request.UserId, request.OperationClaimId);
                await _userOperationClaimBusinessRules.OperationClaimShouldBeExistWhenRequested(request.OperationClaimId);
                await _userOperationClaimBusinessRules.UserShouldBeExistWhenRequested(request.UserId);

                UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
                UserOperationClaim createUserOperationClaim = await _userOperationClaimRepository.AddAsync(mappedUserOperationClaim);
                CreatedUserOperationClaimDto createdUserOperationClaimDto = _mapper.Map<CreatedUserOperationClaimDto>(createUserOperationClaim);

                return createdUserOperationClaimDto;
            }

        }
    }
}

