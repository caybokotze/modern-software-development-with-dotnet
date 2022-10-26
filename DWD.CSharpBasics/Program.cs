// See https://aka.ms/new-console-template for more information

using DWD.Shared;

namespace CSharpBasics;

public static class Program
{
    public static void Main()
    {
        // Invoker.Run<Linq>();
        //
        // var person = new Person()
        // {
        //     FirstName = "John",
        // };
        //
        // var sumOfValues = Math.Add(1, 2, 3.5);
        // Console.WriteLine(sumOfValues);

        var dog = new Dog();
        var cat = new Cat();
        dog.Bark();
        cat.Bark();
    }
}

public static class Math
{
    public static double Add(params double[] values)
    {
        return values.Sum();
    }
}