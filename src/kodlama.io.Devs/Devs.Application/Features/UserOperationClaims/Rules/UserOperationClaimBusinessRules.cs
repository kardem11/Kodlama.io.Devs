using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Devs.Application.Services.Repositories;

namespace Devs.Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IUserRepository _userRepository;

        public UserOperationClaimBusinessRules(IUserOperationClaimRepository userOperationClaimRepository, IOperationClaimRepository operationClaimRepository, IUserRepository userRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _operationClaimRepository = operationClaimRepository;
            _userRepository = userRepository;
        }
        public async Task UserOperationClaimCanNotBeDuplicatedWhenInsertedOrUpdated(int UserId, int OperationClaimId)
        {
            IPaginate<UserOperationClaim> result = await _userOperationClaimRepository.GetListAsync(
                o => o.UserId == UserId && o.OperationClaimId == OperationClaimId, enableTracking: false);
            if (result.Items.Any()) throw new BusinessException("This User Does Not Exist");
        }

        public async Task OperationClaimShouldBeExistWhenRequested(int id)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(o => o.Id == id);
            if (operationClaim == null) throw new BusinessException("This operation claim does not exist");
        }

        public async Task UserShouldBeExistWhenRequested(int id)
        {
            User? user = await _userRepository.GetAsync(o => o.Id == id);
            if (user == null) throw new BusinessException("This operation claim does not exist");
        }

        public async Task UserOperationClaimShouldBeExistWhenRequested(int id)
        {
            UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(o => o.Id == id);
            if (userOperationClaim == null) throw new BusinessException("User operation claim does not exist");
        }

        public async Task ShouldBeSomeDataInTheUserOperationClaimTableWhenRequested(IPaginate<UserOperationClaim> userOperationClaims)
        {
            if (!userOperationClaims.Items.Any()) throw new BusinessException("User operation claim does not exist");
        }
    }
}


