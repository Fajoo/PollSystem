using Microsoft.Extensions.DependencyInjection;

namespace Desktop.ViewModels;

public static class ViewModelRegistrator
{
    public static IServiceCollection AddViews(this IServiceCollection services) => services
        .AddTransient<MainWindowViewModel>()
    ;
}