using Microsoft.AspNetCore.Mvc;
using PollSystem.Api.Controllers.Base;
using PollSystem.Application.CQRS.Options.Commands.CreateOption;

namespace PollSystem.Api.Controllers;

[ApiVersion("1.0")]
[Produces("application/json")]
[Route("api/{version:apiVersion}/[controller]")]
public class OptionController : BaseController
{
    /// <summary>
    /// Description action
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// Post /
    /// </remarks>
    /// <returns>Return Guid</returns>
    /// <response code="201">Success</response>
    /// <response code="401">If the user is unauthorized</response>
    [HttpPost]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> CreateOption([FromBody]CreateOptionCommand model)
    {
        var result = Mediator.Send(model);
        return Ok(result);
    }
}