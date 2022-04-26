using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PollSystem.Api.Controllers.Base;
using PollSystem.Api.Models;
using PollSystem.Application.CQRS.Tags.Commands.RemoveTag;
using PollSystem.Application.CQRS.Tags.Queries.GetTagsByName;

namespace PollSystem.Api.Controllers;

[ApiVersion("1.0")]
[Produces("application/json")]
[Route("api/{version:apiVersion}/[controller]")]
public class TagController : BaseController
{
    private readonly IMapper _mapper;

    public TagController(IMapper mapper) => _mapper = mapper;

    /// <summary>
    /// Description action
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /
    /// </remarks>
    /// <returns>Returns</returns>
    /// <response code="200">Success</response>
    /// <response code="400">Bad request</response>
    [HttpGet("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetTagsByName(string name)
    {
        var query = new GetTagsByNameQuery
        {
            Name = name
        };
        var res = Mediator.Send(query);
        return Ok(res);
    }

    /// <summary>
    /// Description action
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// Delete /
    /// </remarks>
    /// <returns>Returns</returns>
    /// <response code="204">Success</response>
    /// <response code="401">If the user is unauthorized</response>
    [HttpDelete]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> RemoveTag([FromBody]DeleteTagModel model)
    {
        var command = _mapper.Map<RemoveTagCommand>(model);
        command.LoginUser = UserLogin;
        var res = Mediator.Send(command);
        return NoContent();
    }
}