using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PollSystem.Api.Controllers.Base;
using PollSystem.Api.Models;
using PollSystem.Application.CQRS.Categories.Commands.CreateCategory;
using PollSystem.Application.CQRS.Categories.Commands.DeleteCategory;
using PollSystem.Application.CQRS.Categories.Queries.GetAllCategories;
using PollSystem.Application.CQRS.Categories.Queries.GetCategory;

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
    /// <returns>Returns CategoryListViewModel</returns>
    /// <response code="200">Success</response>
    /// <response code="401">If the user is unauthorized</response>
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CategoryListViewModel>> GetCategories()
    {
        var query = new GetAllCategoriesQuery();
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Description action
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /
    /// </remarks>
    /// <returns>Return</returns>
    /// <response code="200">Success</response>
    /// <response code="401">If the user is unauthorized</response>
    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CategoryDto>> GetCategory(Guid id)
    {
        var query = new GetCategoryQuery()
        {
            Id = id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Description action
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /person
    /// </remarks>
    /// <returns>Return GUID</returns>
    /// <response code="200">Success</response>
    /// <response code="401">If the user is unauthorized</response>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CategoryListViewModel>> CreateCategory([FromBody] CreateCategoryModel model)
    {
        var command = _mapper.Map<CreateCategoryCommand>(model);
        var vm = await Mediator.Send(command);
        return Ok(vm);
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
    public async Task<ActionResult> DeleteCategory(Guid id)
    {
        var command = new DeleteCategoryCommand()
        {
            Id = id
        };
        var vm = await Mediator.Send(command);
        return NoContent();
    }
}