using System.Data;
using DWD.Shared;

namespace CSharpBasics;

public class ExceptionHandling : IRunnable
{
    public void Run()
    {
        try
        {
            DoSomeWork();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void DoSomeWork()
    {
        throw new Exception("Something isn't quite right");
    }
}