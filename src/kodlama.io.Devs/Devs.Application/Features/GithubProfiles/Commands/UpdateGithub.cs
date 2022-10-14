using AutoMapper;
using Devs.Application.Features.GithubProfiles.Dtos;
using Devs.Application.Features.GithubProfiles.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.GithubProfiles.Commands
{
    public class UpdateGithub:IRequest<UpdatedGithubDto>
    {
        public int Id { get; set; }
        public class UpdateGithubHandler : IRequestHandler<UpdateGithub, UpdatedGithubDto>
        {
            private readonly IGithubRepository _githubRepository;
            private readonly IMapper _mapper;
            private readonly GithubBusinessRules _githubBusinessRules;

            public UpdateGithubHandler(IGithubRepository githubRepository, IMapper mapper, GithubBusinessRules githubBusinessRules)
            {
                _githubRepository = githubRepository;
                _mapper = mapper;
                _githubBusinessRules = githubBusinessRules;
            }

            public async Task<UpdatedGithubDto> Handle(UpdateGithub request, CancellationToken cancellationToken)
            {
                GithubProfile mappedGithubProfile = _mapper.Map<GithubProfile>(request);
                GithubProfile updatedGithubProfile = await _githubRepository.UpdateAsync(mappedGithubProfile);
                UpdatedGithubDto updatedGithubDto = _mapper.Map<UpdatedGithubDto>(updatedGithubProfile);
                return updatedGithubDto;
            }
        }
    }
}
