using Desktop.Services.Interfaces;
using Desktop.ViewModels.Base;

namespace Desktop.ViewModels;

public class MainWindowViewModel : TittledViewModel
{
    private readonly IHubService _hub;

    public MainWindowViewModel(IHubService hub)
    {
        _hub = hub;
        Tittle = "Главное окно";
    }
}