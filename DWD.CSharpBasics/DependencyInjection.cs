using System.ComponentModel.Design;
using DWD.Shared;

namespace CSharpBasics;

public class DependencyInjection
{
    public class PersonService
    {
        private readonly DatabaseDependency _databaseDependency;

        public PersonService(DatabaseDependency databaseDependency)
        {
            _databaseDependency = databaseDependency;
        }

        public void SavePerson(Person person)
        {
            _databaseDependency.SaveObject(person);
        }
    }

    public class DatabaseDependency
    {
        public void SaveObject(object value)
        {
            // save logic...
        }
    }

    public static class ContainerExtensions
    {
        public static IServiceContainer Add(IServiceContainer serviceContainer)
        {
            serviceContainer.AddService(typeof(PersonService), serviceContainer);
            return serviceContainer;
        }
    }
}