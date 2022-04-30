using System.Collections.Generic;
using Desktop.Models;
using Desktop.Services;
using Desktop.Services.Interfaces;
using Desktop.ViewModels.Base;

namespace Desktop.ViewModels;

public class MainWindowViewModel : TittledViewModel
{
    private readonly SimpleHttpClient _client;

    public MainWindowViewModel(SimpleHttpClient client)
    {
        _client = client;
        var res = _client.GetAsync<CategoryList>("Category").Result;
        Tittle = "Главное окно";
    }
}