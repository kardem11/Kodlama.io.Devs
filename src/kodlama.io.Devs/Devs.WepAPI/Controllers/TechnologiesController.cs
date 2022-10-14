using Core.Application.Requests;
using Devs.Application.Features.ProgrammingLanguages.Dtos;
using Devs.Application.Features.Technologies.Commands.CreateTechnology;
using Devs.Application.Features.Technologies.Commands.DeleteTechnology;
using Devs.Application.Features.Technologies.Commands.UpdateTechnology;
using Devs.Application.Features.Technologies.Dtos;
using Devs.Application.Features.Technologies.Models;
using Devs.Application.Features.Technologies.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Devs.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : BaseController
    {
        private readonly IMediator _mediator;
        public TechnologiesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]PageRequest pageRequest)
        {
            GetListTechnologyQuery getListTechnologyQuery = new() { PageRequest = pageRequest};
            TechnologyListModel result = await _mediator.Send(getListTechnologyQuery);
                return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeleteTechnologyCommand deleteTechnologyCommand)
        {
            DeletedTechnologyDto result = await _mediator.Send(deleteTechnologyCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateTechnologyCommand updateTechnologyCommand)
        {
            UpdatedTechnologyDto result = await _mediator.Send(updateTechnologyCommand);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateTechnologyCommand createTechnologyCommand)
        {
            CreatedTechnologyDto result = await _mediator.Send(createTechnologyCommand);
            return Ok(result);
        }
    }
}
