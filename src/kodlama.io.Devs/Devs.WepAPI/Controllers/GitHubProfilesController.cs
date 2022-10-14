using Devs.Application.Features.GithubProfiles.Commands;
using Devs.Application.Features.GithubProfiles.Dtos;
using Devs.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubProfilesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GitHubProfilesController(IMediator mediator)
        {
           _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateGithub createGithub)
        {
            CreatedGithubDto result = await _mediator.Send(createGithub);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateGithub updateGithub)
        {
            UpdatedGithubDto result = await _mediator.Send(updateGithub);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeleteGithub deleteGithub)
        {
            DeletedGithubDto result = await _mediator.Send(deleteGithub);
            return Ok(result);
        }
    }
}
