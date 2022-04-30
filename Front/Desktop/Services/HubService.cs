using System;
using System.Threading.Tasks;
using Desktop.Services.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Desktop.Services;

public class HubService : IHubService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<HubService> _logger;
    private HubConnection _hub;

    public HubService(IConfiguration configuration, ILogger<HubService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public async Task ConnectAsync(string token)
    {
        _hub = new HubConnectionBuilder()
            .WithUrl($"{_configuration["Hub:Url"]}?token={token}")
            .AddMessagePackProtocol()
            .WithAutomaticReconnect()
            .Build();

        _hub.Closed += HubOnClosed;
        await _hub.StartAsync();
    }

    private Task HubOnClosed(Exception? arg)
    {
        _logger.LogInformation(arg?.Message);
        return Task.CompletedTask;
    }
}