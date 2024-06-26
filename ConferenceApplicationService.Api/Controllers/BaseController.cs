using Microsoft.AspNetCore.Mvc;

namespace ConferenceApplicationServiceApi.Controllers;

[ApiController]
[Route("/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected ActionResult<TResult> OkOrNotFound<TResult>(TResult result)
        => result is null ? NotFound() : Ok(result);
}