using System.Text.Json;
using DWD.Shared;

namespace Minimal.API.WithValidation;

public interface IPersonService
{
    string Execute(Person person);
}

public class PersonService : IPersonService
{
    public string Execute(Person person)
    {
        if (person.Age == 0)
        {
            person.Age = 32;
        }
        
        return JsonSerializer.Serialize(person);
    }
}