using DWD.Shared;

namespace CSharpAdvanced;

/// <summary>
/// In this example we print out the property names and values of an object. This can easily be done without using reflection,
/// However, in some cases there are problems which can not easily be solved without using reflection so it is a very useful tool to be aware of.
/// </summary>
public class ReflectionExamples : IRunnable
{
    public void Run()
    {
        var user = new User
        {
            FirstName = Faker.Name.First(),
            LastName = Faker.Name.Last(),
            Age = DateTime.UtcNow.Year - Faker.Identification.DateOfBirth().Year
        };

        var age = user.Age;
        
        // print out all the property names for person without reflection
        Console.WriteLine("Property names without reflection");
        Console.WriteLine(nameof(user.Id));
        Console.WriteLine(nameof(user.Age));
        Console.WriteLine(nameof(user.FirstName));
        Console.WriteLine(nameof(user.LastName));
        
        // print out the object property names alone using reflection.
        Console.WriteLine("Property names with reflection");
        
        foreach (var property in typeof(User).GetProperties())
        {
            Console.WriteLine(property.Name);
        }
        
        // print out the object properties and its corresponding value
        Console.WriteLine("Property name and value with reflection");
        foreach (var property in typeof(User).GetProperties())
        {
            Console.WriteLine("Property name: {0}. Property value: {1}", property.Name, property.GetValue(user));
        }
    }
}