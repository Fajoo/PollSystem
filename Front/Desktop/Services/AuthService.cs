using System;
using System.Threading.Tasks;
using Desktop.Infrastructure;
using Desktop.Services.Interfaces;
using HandyControl.Controls;
using IdentityModel.OidcClient;
using Microsoft.Extensions.Configuration;

namespace Desktop.Services;

public class AuthService
{
    private readonly IConfiguration _configuration;
    private readonly IHubService _hub;

    private readonly OidcClient _client;

    public AuthService(IConfiguration configuration, IHubService hub)
    {
        _configuration = configuration;
        _hub = hub;

        _client = new OidcClient(new OidcClientOptions
        {
            Authority = _configuration["Client:Authority"],
            ClientId = "wpf-app",
            Scope = "openid profile PollSystemAPI PollSystem.SignalR offline_access",
            RedirectUri = _configuration["Client:RedirectUri"],
            Browser = new WpfEmbeddedBrowser()
        });
    }

    public async Task<LoginResult> LoginAsync()
    {
        try
        {
            var result = await _client.LoginAsync();
            await _hub.ConnectAsync(result.AccessToken);
            return result;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        return null;
    }

    public async Task LogoutAsync()
    {
        await _client.LogoutAsync();
    }

    public async Task RefreshTokenAsync(string refresh)
    {
        var newAccessTokenResponse = await _client.RefreshTokenAsync(refresh);
        if (newAccessTokenResponse.IsError)
            await LoginAsync();
    }
}