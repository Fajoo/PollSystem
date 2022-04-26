using System.Runtime.InteropServices.ComTypes;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PollSystem.Api.Controllers.Base;
using PollSystem.Api.Models;
using PollSystem.Application.CQRS.Questions.Commands.CreateQuestion;
using PollSystem.Application.CQRS.Questions.Queries.GetAllQuestions;

namespace PollSystem.Api.Controllers;

[ApiVersion("1.0")]
[Produces("application/json")]
[Route("api/{version:apiVersion}/[controller]")]
public class QuestionController : BaseController
{
    private readonly IMapper _mapper;

    public QuestionController(IMapper mapper) => _mapper = mapper;

    /// <summary>
    /// Description action
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /
    /// </remarks>
    /// <returns>Returns</returns>
    /// <response code="200">Success</response>
    /// <response code="401">If the user is unauthorized</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<QuestionDtoList>> GetQuestions([FromQuery] int count = 10, [FromQuery] int page = 1)
    {
        var query = new GetAllQuestionsQuery
        {
            Count = count,
            CurrentPage = page
        };
        var res = Mediator.Send(query);
        return Ok(res);
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
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> CreateQuestion([FromBody] CreateQuestionCommand model)
    {
        var res = Mediator.Send(model);
        return Ok(res);
    }
}