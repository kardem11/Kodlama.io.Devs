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
    public class CreateGithub:IRequest<CreatedGithubDto>
    {
        public int UserId { get; set; }
        public string GithubUrl { get; set; }
        public class CreateGithubHandler : IRequestHandler<CreateGithub, CreatedGithubDto>
        {
            private readonly IGithubRepository _githubRepository;
            private readonly GithubBusinessRules _githubBusinessRules;
            private readonly IMapper _mapper;

            public CreateGithubHandler(IGithubRepository githubRepository, GithubBusinessRules githubBusinessRules, IMapper mapper)
            {
                _githubRepository = githubRepository;
                _githubBusinessRules = githubBusinessRules;
                _mapper = mapper;
            }

            public async Task<CreatedGithubDto> Handle(CreateGithub request, CancellationToken cancellationToken)
            {
                await _githubBusinessRules.GithubAddressCanNotBeDuplicatedWhenInserted(request.GithubUrl);
                GithubProfile mappedGithubProfile = _mapper.Map<GithubProfile>(request);
                GithubProfile createdGithub = await _githubRepository.AddAsync(mappedGithubProfile);
                CreatedGithubDto createdGithubDto = _mapper.Map<CreatedGithubDto>(createdGithub);
                return createdGithubDto;
            }
        }
    }
}
