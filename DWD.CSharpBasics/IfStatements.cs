using DWD.Shared;

namespace CSharpBasics;

public class BasicIf : IRunnable
{
    public void Run()
    {
        var a = 1;
        var b = 2;

        if (a == b)
        {
            Console.WriteLine("a is equal to b");
        }
    }
}

public class IfWithMultipleConditions : IRunnable
{
    public void Run()
    {
        var a = 1;
        var b = 2;

        if ((a == 1 || b == 1) && a + b >= b) {
            Console.WriteLine("a or b is 1 and the sum of a and b is greater than or equal to the value of b");
        }
    }
}