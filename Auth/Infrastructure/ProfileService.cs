using System.Security.Claims;
using Auth.Identity.Models;
using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;

namespace Auth.Identity.Infrastructure;

// Взаимодействие с клаимами
public class ProfileService : IProfileService
{
    private readonly UserManager<AppUser> _userManager;

    public ProfileService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var sub = context.Subject.GetSubjectId();
        var user = await _userManager.FindByIdAsync(sub);

        var claims = new List<Claim>
        {
            new(JwtClaimTypes.Name, user.UserName),
        };

        context.IssuedClaims.AddRange(claims);
    }

    // Подтверждение активности пользователя (обязательно, без него не выполняется метод выше)
    public Task IsActiveAsync(IsActiveContext context)
    {
        context.IsActive = true;

        return Task.CompletedTask;
    }
}