using DWD.Shared;

namespace CSharpBasics;

public class SwitchStatements : IRunnable
{
    public void Run()
    {
        var a = 1;
        var b = 2;
        var result = a + b;

        switch (result)
        {
            case 1: Console.WriteLine("The result is 1");
                break;
            case 2: Console.WriteLine("The result is 2");
                break;
            case 3: Console.WriteLine("The result is 3");
                break;
            default: Console.WriteLine("The result is not expected");
                break;
        }
    }
}

public class SwitchExpression : IRunnable
{
    public void Run()
    {
        var a = 1;
        var b = 2;
        var result = a + b;
        var resultPlusOne = result switch
        {
            1 => 1 + 1,
            2 => 2 + 1,
            3 => 3 + 1,
            _ => 0
        };
        
        Console.WriteLine(resultPlusOne);
    }
}