using ApplicationsService.Abstractions.Commands;
using ApplicationsService.Abstractions.Queries;
using ApplicationsService.Application.Commands.CreateCommand;
using ApplicationsService.Application.Commands.DeleteCommand;
using ApplicationsService.Application.Commands.EditCommand;
using ApplicationsService.Application.Commands.SendCommand;
using ApplicationsService.Application.DTO;
using ApplicationsService.Application.Queries.GetByDateQuery;
using ApplicationsService.Application.Queries.GetByIdQuery;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceApplicationServiceApi.Controllers;

public class ApplicationsController : BaseController
{
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public ApplicationsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApplicationDto>> Get([FromRoute] GetApplicationQuery query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }
        
        [HttpGet("users/{userId:guid}/currentapplication")]
        public async Task<ActionResult<ApplicationDto>> Get([FromRoute] GetApplicationByUserIdQuery query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }
        
        [HttpGet("unsubmittedOlder={date:datetime}")]
        public async Task<ActionResult<IEnumerable<ApplicationDto>>> Get([FromQuery(Name = "unsubmittedOlder")] GetUnsubmittedApplicationsByDateQuery query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }
        [HttpGet("submittedAfter={date:datetime}")]
        public async Task<ActionResult<IEnumerable<ApplicationDto>>> Get([FromQuery(Name = "submittedAfter")] GetSubmittedApplicationsByDateQuery query)
        {
            var result = await _queryDispatcher.QueryAsync(query);
            return OkOrNotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateApplicationCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(Get), new {id = command.userId}, null);
        }
        
        [HttpPut("{id:guid}/submit")]
        public async Task<IActionResult> Put([FromRoute] SendApplicationCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }
        
        [HttpPut("{applicationId:guid}")]
        public async Task<IActionResult> Put([FromBody] EditApplicationCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromBody] DeleteApplicationCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }
}