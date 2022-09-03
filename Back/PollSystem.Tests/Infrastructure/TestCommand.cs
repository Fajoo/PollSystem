using System;
using PollSystem.Persistence;

namespace PollSystem.Tests.Infrastructure;

public class TestCommand : IDisposable
{

    protected readonly PollSystemDbContext Context;

    public TestCommand()
    {
        Context = DbContextHelper.CreateContext();
    }

    public void Dispose()
    {
        DbContextHelper.Destroy(Context);
    }
}