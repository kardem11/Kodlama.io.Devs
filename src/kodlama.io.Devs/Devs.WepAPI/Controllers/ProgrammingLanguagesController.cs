using Core.Application.Requests;
using Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Devs.Application.Features.ProgrammingLanguages.Dtos;
using Devs.Application.Features.ProgrammingLanguages.Models;
using Devs.Application.Features.ProgrammingLanguages.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProgrammingLanguagesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() { PageRequest = pageRequest};
            ProgrammingLanguageListModel result = await _mediator.Send(getListProgrammingLanguageQuery);

            return Ok( result );
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetById([FromRoute]GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
        {
            ProgrammingLanguageGetByIdDto result = await _mediator.Send(getByIdProgrammingLanguageQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            DeletedProgrammingLanguageDto result = await _mediator.Send(createProgrammingLanguageCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        {
            UpdatedProgrammingLanguageDto result = await _mediator.Send(updateProgrammingLanguageCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            DeletedProgrammingLanguageDto result = await _mediator.Send(deleteProgrammingLanguageCommand);
            return Ok(result);
        }
    }
}
