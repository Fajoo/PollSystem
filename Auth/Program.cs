using Auth.Identity.Data;
using Serilog;
using Serilog.Events;

namespace Auth.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var logging = new LoggerConfiguration()
            //    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            //    .WriteTo.File("AuthIdentity-.txt", rollingInterval:
            //        RollingInterval.Day)
            //    .CreateLogger();

            var host = CreateHostBuilder(args).Build();
            using(var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<DbInitializer>>();
                    var context = serviceProvider.GetRequiredService<AuthDbContext>();
                    var init = new DbInitializer(logger);
                    init.Initialize(context);
                }
                catch (Exception exception)
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exception, "An error occurred while app initialization");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((context, configuration) => configuration
                        .Enrich.FromLogContext()
                        .MinimumLevel.Information()
                        .WriteTo.File("AuthIdentity-.txt", rollingInterval:
                            RollingInterval.Day)
                        .WriteTo.Console(),
                    preserveStaticLogger: true)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
