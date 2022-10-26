using DWD.Shared;

namespace CSharpAdvanced;

/// <summary>
/// This code illustrates two ways in which a variable reference swap can be done.
/// A reference swap means taking a variable reference and assigning it to a different variable. And doing the same for the second variable.
/// The result is that the value for variable 1 is now assigned to variable 2 and variable 2 to variable 1.
/// This can easily be done by copying the value instead, however doing it by reference can offer some performance benefits.
/// </summary>
public class UnsafeCode : IRunnable
{
    public void Run()
    {
        int i = 10, j = 20;
        Console.WriteLine("Safe swap");
        Console.WriteLine("values before safe swap: i = {0}, j = {1}", i, j);
        SafeSwap(ref i, ref j);
        Console.WriteLine("Values after safe swap: i = {0}, j = {1}", i, j);

        Console.WriteLine("Unsafe swap");
        Console.WriteLine("Values before unsafe swap: i = {0}, j = {1}", i, j);
        unsafe { UnsafeSwap(&i, &j); }
        Console.WriteLine("Values after unsafe swap: i = {0}, j = {1}", i, j);
    }
    
    public unsafe static void UnsafeSwap(int* i, int* j)
    {
        var b = 1;
        var c = new {name = "object"};
        var someAddress = &b;
        var temp = *i;
        *i = *j;
        *j = temp;
    }

    public static void SafeSwap(ref int i, ref int j) 
    {
        int temp = i;
        i = j;
        j = temp;
    }
}