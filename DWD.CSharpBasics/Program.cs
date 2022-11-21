// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using CSharpBasics.Animals;
// using CSharpBasics.Animals;
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

        // var dog = new Dog();
        // var cat = new Cat();
        // dog.Bark();
        // cat.Bark();

        // var invoker = new Invoker();
        // var person = invoker.CreateInstance<Person>();
        // Console.WriteLine(JsonSerializer.Serialize(person));
        // var dog = new Dog();

        var sb = new StringBuilder();
        sb.Append("I am your new neighbour.");
        sb.Append("Hi I am John.");
        sb.Append("Welcome to the street!");
        // var chunks = sb[];
        
        Console.WriteLine(sb.ToString());
    }
}

public static class Math
{
    public static double Add(params double[] values)
    {
        return values.Sum();
    }
}