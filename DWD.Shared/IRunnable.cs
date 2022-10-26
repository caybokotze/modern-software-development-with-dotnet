namespace DWD.Shared;

public interface IRunnable
{
    void Run();
}

public static class Invoker
{
    public static void Run<T>() where T : IRunnable, new()
    {

        new Person();
        new T().Run();
    }
}