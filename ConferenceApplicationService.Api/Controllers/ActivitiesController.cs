using ApplicationsService.Abstractions.Commands;
using ApplicationsService.Abstractions.Queries;
using ApplicationsService.Domain.Consts;
using ApplicationsService.Infrastructure.EF.Options;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceApplicationServiceApi.Controllers;

public class ActivitiesController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public ActivitiesController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet]
    [Route("/activities")]
    public IActionResult GetActivityTypes()
    {
        return Ok(EnumExtensions.GetValues<ActivityType>());
    }

}