using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Devs.Application.Features.GithubProfiles.Models;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.GithubProfiles.Queries
{
    public class GetListGitHubQuery:IRequest<GithubListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListGithubQueryHandler : IRequestHandler<GetListGitHubQuery, GithubListModel>
        {
            private readonly IGithubRepository _githubRepository;
            private readonly IMapper _mapper;
            public async Task<GithubListModel> Handle(GetListGitHubQuery request, CancellationToken cancellationToken)
            {
                IPaginate<GithubProfile> profiles = await _githubRepository
                .GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                GithubListModel githubListModel = _mapper.Map<GithubListModel>(profiles);
                return githubListModel;
            }
        }
    }
}
