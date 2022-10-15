using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Devs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
           
        }
        public async Task OperationClaimNameCanNotBeDuplicatedWhenInsertedOrUpdated(string name)
        {
            IPaginate<OperationClaim> result = await _operationClaimRepository.GetListAsync(o => o.Name == name, enableTracking: false);
            if(result.Items.Any()) throw new BusinessException("This Role Already Exists");
        }
        public async Task OperationClaimShouldBeExistWhenRequested(int id)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(o => o.Id == id);
            if (operationClaim == null) throw new BusinessException("This Role Already Exists");
        }
        public async Task ShouldBeSomeDataInTheOperationClaimTableWhenRequested(IPaginate<OperationClaim> operationClaims)
        {
            if (!operationClaims.Items.Any()) throw new BusinessException("This Role Already Exists");
        }

        public async Task UserOperationClaimShouldNotBeExistWhenTryingToDeleteOperationClaim(int id)
        {
            UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(o => o.OperationClaimId == id);
            if (userOperationClaim != null) throw new BusinessException("This Role Already Exists");
        }
    }
}
