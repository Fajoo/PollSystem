using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PollSystem.Api.Controllers.Base;
using PollSystem.Application.CQRS.Categories.Queries.GetAllCategories;

namespace PollSystem.Api.Controllers;

[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Produces("application/json")]
[Route("api/{version:apiVersion}/[controller]")]
public class CategoryController : BaseController
{
    private readonly IMapper _mapper;

    public CategoryController(IMapper mapper) => _mapper = mapper;

    /// <summary>
    /// Description action
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /person
    /// </remarks>
    /// <returns>Returns</returns>
    /// <response code="200">Success</response>
    /// <response code="401">If the user is unauthorized</response>
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CategoryListViewModel>> GetCategories()
    {
        var query = new GetAllCategoriesQuery();
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
}