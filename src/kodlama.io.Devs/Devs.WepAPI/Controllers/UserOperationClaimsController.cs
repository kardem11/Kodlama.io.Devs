using Core.Application.Requests;
using Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Devs.Application.Features.UserOperationClaims.Dtos;
using Devs.Application.Features.UserOperationClaims.Models;
using Devs.Application.Features.UserOperationClaims.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpPost("create")]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            CreatedUserOperationClaimDto result = await Mediator.Send(createUserOperationClaimCommand);
            return Created("Created Successfully.", result);
        }
        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest)
        {
            GetListUserOperationClaimQuery getListUserOperationClaimQuery = new() { PageRequest = pageRequest };
            UserOperationClaimListModel result = await Mediator.Send(getListUserOperationClaimQuery);
            return Ok(result);
        }
        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            DeleteUserOperationClaimCommand deleteUserOperationClaimCommand = new() { Id = Id };
            DeletedUserOperationClaimDto result = await Mediator.Send(deleteUserOperationClaimCommand);
            return Ok(result);
        }

    }
}
