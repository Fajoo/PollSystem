using Microsoft.Extensions.DependencyInjection;

namespace Desktop.ViewModels;

public class ViewModelLocator
{
    public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
}