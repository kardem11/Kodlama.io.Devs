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
    public class DeleteGithub : IRequest<DeletedGithubDto>
    {
        public int Id { get; set; }
        public class DeleteGithubHandler : IRequestHandler<DeleteGithub, DeletedGithubDto>
        {
            private readonly IGithubRepository _githubRepository;
            private readonly GithubBusinessRules _githubBusinessRules;
            private readonly IMapper _mapper;

            public DeleteGithubHandler(IGithubRepository githubRepository, GithubBusinessRules githubBusinessRules, IMapper mapper)
            {
                _githubRepository = githubRepository;
                _githubBusinessRules = githubBusinessRules;
                _mapper = mapper;
            }

            public async Task<DeletedGithubDto> Handle(DeleteGithub request, CancellationToken cancellationToken)
            {
                GithubProfile mappedGithubProfile = _mapper.Map<GithubProfile>(request);
                GithubProfile deletedGithub = await _githubRepository.DeleteAsync(mappedGithubProfile);
                DeletedGithubDto deletedGithubDto = _mapper.Map<DeletedGithubDto>(deletedGithub);
                return deletedGithubDto;
            }
        }
    }
}
