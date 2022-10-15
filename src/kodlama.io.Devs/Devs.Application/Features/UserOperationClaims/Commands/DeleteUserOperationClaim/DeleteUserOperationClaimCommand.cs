using Core.Application.Pipelines.Authorization;
using Devs.Application.Features.UserOperationClaims.Dtos;
using Devs.Application.Features.UserOperationClaims.Rules;
using Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles { get; } = { "Admin" };

        class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand,
            DeletedUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

            public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository,
                UserOperationClaimBusinessRules userOperationClaimBusinessRules)
                => (_userOperationClaimRepository, _userOperationClaimBusinessRules) =
                    (userOperationClaimRepository, userOperationClaimBusinessRules);

            public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request,
                CancellationToken cancellationToken)
            {
                var userOperationClaim = await _userOperationClaimRepository.GetAsync(u => u.Id == request.Id);

                _userOperationClaimBusinessRules.Equals(userOperationClaim);

                var deletedUserOperationClaim = await _userOperationClaimRepository.DeleteAsync(userOperationClaim);

                var deletedUserOperationClaimDto = new DeletedUserOperationClaimDto();

                return deletedUserOperationClaimDto;
            }
        }
    }
}
