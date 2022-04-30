using Desktop.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Desktop.Services;

public static class ServiceRegistrator
{
    public static IServiceCollection AddServices(this IServiceCollection services) => services
        .AddTransient<IUserDialog, UserDialogService>()
        .AddSingleton<AuthService>()
        .AddSingleton<IHubService, HubService>()
    ;
}