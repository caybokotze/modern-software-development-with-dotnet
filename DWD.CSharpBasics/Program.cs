// See https://aka.ms/new-console-template for more information

using System.Text;
using DWD.Shared;

namespace CSharpBasics;

public static class Program
{
    public static void Main()
    {
        LoopExamples.Execute();
    }
}

/*
 * When should you use static classes / methods?
 * When declaring classes that you want to want to contain global state. Like with constant values.
 * For pure methods. Methods that for a given input always yield the same output. Like math methods.
 *
 * When to not use static methods / classes?
 * To maintain global service state, like authentication tokens etc. Rather use Singleton or Scoped dependencies.
 * For methods that handle changing data state. Like database calls or object instance specific data.
 */
public static class LoopExamples
{
    public static void Execute()
    {
        Invoker.Run<ForLoop>();
    }
}