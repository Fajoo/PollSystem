using System;
using Desktop.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Desktop.Services;

public static class ServiceRegistrator
{
    public static IHttpClientBuilder AddServices(this IServiceCollection services) => services
        .AddTransient<IUserDialog, UserDialogService>()
        .AddSingleton<AuthService>()
        .AddSingleton<IHubService, HubService>()
        .AddHttpClient<SimpleHttpClient>(opt =>
        {
            opt.BaseAddress = new Uri("https://localhost:7207/api/1.0/");
        })
    ;
}