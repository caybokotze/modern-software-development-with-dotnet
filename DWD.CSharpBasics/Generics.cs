using DWD.Shared;

namespace CSharpBasics;

public class Manager
{
    public void AddAsAdministrator<T>(Person person) where T : IAdministrator
    {
        //
    }

    public void AddAsSecretary(Person person)
    {
        //
    }
}


public class Implementation
{
    public void Run()
    {
    //     var person = new Person("John");
    //     var manager = new Manager();
    //     
        // manager.AddAsAdministrator<Person>(person);

        var invoker = new Invoker();
        var person = invoker.CreateInstance<Person>();
    }
    
}

public class Invoker
{
    public T CreateInstance<T>() where T : IAdministrator, ISecretary, new()
    {
        var obj =  new T();
        obj.IsAdministrator = true;
        obj.IsSecretary = true;
        return obj;
    }
}


