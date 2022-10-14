using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.GithubProfiles.Rules
{
    public class GithubBusinessRules
    {
        private readonly IGithubRepository _githubRepository;
        public GithubBusinessRules(IGithubRepository githubRepository)
        {
            _githubRepository = githubRepository;
        }
        public async Task GithubAddressCanNotBeDuplicatedWhenInserted(string githubUrl)
        {
            IPaginate<GithubProfile> result = await _githubRepository.GetListAsync(g=> g.Equals(githubUrl));
            if (result.Items.Any()) throw new BusinessException("Github account already exist.");
        }
        public void GithubAddressShouldExistWhenRequested(GithubProfile githubProfile)
        {
            if (githubProfile == null) throw new BusinessException("Requested Github account does not exist.");
        }
    }
}
