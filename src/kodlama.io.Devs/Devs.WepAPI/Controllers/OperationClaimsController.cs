using Core.Application.Requests;
using Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Devs.Application.Features.OperationClaims.Dtos;
using Devs.Application.Features.OperationClaims.Models;
using Devs.Application.Features.OperationClaims.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        [HttpPost("create")]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
        {
            CreatedOperationClaimDto result = await Mediator.Send(createOperationClaimCommand);
            return Created("Created successfully.", result);
        }
        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            DeleteOperationClaimCommand deleteOperationClaimCommand = new() { Id = Id };
            DeletedOperationClaimDto result = await Mediator.Send(deleteOperationClaimCommand);
            return Created("Created successfully.", result);
        }
        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest)
        {
            GetListOperationClaimQuery getListOperationClaimQuery = new() { PageRequest = pageRequest };
            OperationClaimListModel result = await Mediator.Send(getListOperationClaimQuery);
            return Ok(result);
        }


    }
}
