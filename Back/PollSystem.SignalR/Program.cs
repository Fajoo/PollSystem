using Microsoft.AspNetCore.Authentication.JwtBearer;
using PollSystem.SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR()
    .AddMessagePackProtocol();
builder.Services.AddCors(op =>
{
    op.DefaultPolicyName = "PollSystem.SignalRCors";
    op.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder.SetIsOriginAllowed(_ => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyHeader();
    });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:44386/";
        options.Audience = "PollSystem.SignalR";
        options.RequireHttpsMetadata = false;

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var token = context.Request.Query["token"];
                if (!string.IsNullOrWhiteSpace(token) && context.Request.Path.StartsWithSegments("/notification"))
                    context.Token = token;

                return Task.CompletedTask;
            }

        };
    });

var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("PollSystem.SignalRCors");
app.MapGet("/notification", () => "Use SignalR");
app.MapHub<NotificationHub>("/notification");

app.Run();
