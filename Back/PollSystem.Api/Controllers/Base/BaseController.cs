using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PollSystem.Api.Controllers.Base;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class BaseController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Mediator =>
        _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    internal Guid UserId => !User.Identity.IsAuthenticated
        ? Guid.Empty
        : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

    internal string UserLogin => !User.Identity.IsAuthenticated
        ? string.Empty
        : User.FindFirst(ClaimTypes.Name).Value;
}