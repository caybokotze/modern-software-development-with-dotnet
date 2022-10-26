namespace CSharpBasics;

interface IFurInterface
{
    bool HasFur { get; set; }
}
public class Dog : Animal, IFurInterface
{
    public string? Name { get; set; }
    public bool HasFur { get; set; }

    public void Bark()
    {
        Console.WriteLine("I am a dog!");
    }
}

public class Cat : Animal, IFurInterface
{
    public string? Name { get; set; }
    public bool HasFur { get; set; }
}

public class Animal
{
    public bool CanWalk { get; set; }

    public void Bark()
    {
        Console.WriteLine("Bark!");
    }
}