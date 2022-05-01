using System.Windows;
using Desktop.Infrastructure.Commands.Base;

namespace Desktop.Infrastructure.Commands;

public class MinMaxWindow : Command
{
    public override void Execute(object? parameter) =>
        App.ActivedWindow.WindowState = App.ActivedWindow.WindowState switch
        {
            WindowState.Normal => WindowState.Maximized,
            WindowState.Maximized => WindowState.Normal,
            _ => App.ActivedWindow.WindowState
        };

    public override bool CanExecute(object? parameter) => App.ActivedWindow != null;
}