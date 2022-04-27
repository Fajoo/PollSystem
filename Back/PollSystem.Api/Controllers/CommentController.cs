using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PollSystem.Api.Controllers.Base;
using PollSystem.Api.Models;
using PollSystem.Application.CQRS.Comments.Commands.CreateComment;
using PollSystem.Application.CQRS.Comments.Commands.RemoveComment;
using PollSystem.Application.CQRS.Comments.Queries.GetComments;

namespace PollSystem.Api.Controllers;

[ApiVersion("1.0")]
[Produces("application/json")]
[Route("api/{version:apiVersion}/[controller]")]
public class CommentController : BaseController
{
    private readonly IMapper _mapper;

    public CommentController(IMapper mapper) => _mapper = mapper;

    /// <summary>
    /// Description action
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /
    /// </remarks>
    /// <returns>Retur CommentDtoList</returns>
    /// <response code="200">Success</response>
    /// <response code="401">If the user is unauthorized</response>
    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CommentDtoList>> GetComments(Guid id, [FromQuery] int count = 10, [FromQuery] int page = 1)
    {
        var command = new GetCommentsCommand
        {
            QuestionId = id,
            Count = count,
            CurrentPage = page
        };
        var result = Mediator.Send(command);
        return Ok(result);
    }

    /// <summary>
    /// Description action
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// Post /
    /// </remarks>
    /// <returns>Returns</returns>
    /// <response code="201">Success</response>
    /// <response code="401">If the user is unauthorized</response>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> CreateComment([FromBody] CreateCommentModel model)
    {
        var command = _mapper.Map<CreateCommentCommand>(model);
        command.UserLogin = UserLogin;
        var result = Mediator.Send(command);
        return Ok(result);
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
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> RemoveComment(Guid id)
    {
        var command = new RemoveCommentCommand
        {
            CommentId = id,
            LoginUser = UserLogin
        };
        var result = Mediator.Send(command);
        return NoContent();
    }
}