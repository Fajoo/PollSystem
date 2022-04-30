namespace PollSystem.SignalR.Interfaces;

public interface INotificationClient
{
    Task Send(string msg);
}