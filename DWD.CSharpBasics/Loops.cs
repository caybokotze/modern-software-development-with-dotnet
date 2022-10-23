using System.Text.Json;
using DWD.Shared;

namespace CSharpBasics;

public class WhileLoop : IRunnable
{
    public void Run()
    {
        var i = 1;

        while (true)
        {
            Console.WriteLine($"This is iteration number {i}");

            if (i >= 10)
            {
                break;
            }
            
            i += 1;
        }
    }
}

public class ForLoop : IRunnable
{
    public void Run()
    {
        for (var i = 0; i <= 10; i++)
        {
            Console.WriteLine("This is iteration number {i}");       
        }
    }
}

public class ForEachLoop : IRunnable
{
    public void Run()
    {
        var people = new List<Person>()
        {
            new()
            {
                FirstName = Faker.Name.First(),
                LastName = Faker.Name.Last(),
                Age = DateTime.UtcNow.Year - Faker.Identification.DateOfBirth().Year
            },
            new()
            {
                FirstName = Faker.Name.First(),
                LastName = Faker.Name.Last(),
                Age = DateTime.UtcNow.Year - Faker.Identification.DateOfBirth().Year
            },
            new()
            {
                FirstName = Faker.Name.First(),
                LastName = Faker.Name.Last(),
                Age = DateTime.UtcNow.Year - Faker.Identification.DateOfBirth().Year
            }
        };

        foreach (var person in people)
        {
            Console.WriteLine(JsonSerializer.Serialize(person));
        }
    }
}