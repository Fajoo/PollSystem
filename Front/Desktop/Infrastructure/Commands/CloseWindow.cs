#nullable enable
using System.Windows;
using Desktop.Infrastructure.Commands.Base;

namespace Desktop.Infrastructure.Commands;

public class CloseWindow : Command
{
    public override bool CanExecute(object? parameter) => parameter is Window;
    public override void Execute(object? parameter) => (parameter as Window)?.Close();
}