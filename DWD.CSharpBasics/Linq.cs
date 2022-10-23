using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using DWD.Shared;

namespace CSharpBasics;

public class Linq : IRunnable
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
        
        // find the first person with the lowest age.
        var youngestPersonQuerySyntax = (from person in people orderby person.Age select person).First();
        var youngestPersonExpression = people.OrderBy(a => a.Age).First();
        var youngestPersonShortExpression = people.MinBy(m => m.Age);

        Console.WriteLine("Youngest Person via query: {0}", JsonSerializer.Serialize(youngestPersonQuerySyntax));
        Console.WriteLine("Youngest Person via expression: {0}", JsonSerializer.Serialize(youngestPersonExpression));
        Console.WriteLine("Youngest Person via short expression: {0}", JsonSerializer.Serialize(youngestPersonShortExpression));
        Console.WriteLine("All ages: {0}", JsonSerializer.Serialize(people.Select(s => s.Age)));
    }
}