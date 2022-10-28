namespace CSharpBasics;

public class Delegates
{
    public delegate int Foo();
}

public class DelegateHandler
{
    public event Delegates.Foo? FooHandler;
}