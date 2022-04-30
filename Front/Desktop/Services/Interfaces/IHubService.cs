using System.Threading.Tasks;

namespace Desktop.Services.Interfaces;

public interface IHubService
{
    Task ConnectAsync(string token);
}