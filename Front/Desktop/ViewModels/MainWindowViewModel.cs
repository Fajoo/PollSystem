using System.Collections.Generic;
using System.Windows.Input;
using Desktop.Infrastructure.Commands;
using Desktop.Models;
using Desktop.Services;
using Desktop.Services.Interfaces;
using Desktop.ViewModels.Base;
using HandyControl.Controls;

namespace Desktop.ViewModels;

public class MainWindowViewModel : TittledViewModel
{
    private readonly SimpleHttpClient _client;

    #region Page : Page - Page

    /// <summary>Page</summary>
    private Page _page = new();

    /// <summary>Page</summary>
    public Page Page { get => _page; set => Set(ref _page, value); }

    #endregion

    public MainWindowViewModel(SimpleHttpClient client)
    {
        _client = client;
        _client.UpdateToken();
        //var res = _client.GetAsync<CategoryList>("Category").Result;
        Tittle = "Главное окно";
    }

    private ICommand _testCommand;

    public ICommand TestCommand => _testCommand ?? new LambdaCommandAsync(async obj =>
    {
        var res = await _client.CreateAsync("Category", new Category
        {
            Name = "WPF",
            Description = "WPF"
        });
        MessageBox.Show(res.Code.ToString());
    }, _ => true);

}