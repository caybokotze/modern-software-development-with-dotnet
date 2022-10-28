using System;
using System.ComponentModel;
using System.Linq;

namespace DWD.UnitTesting;

public interface ISumService
{
    int Add(params int[] values);
}

public class SumService : ISumService
{
    public SumService(int a, int b, int c)
    {
        
    }
    
    public int Add(params int[] values)
    {
        return values.Sum();
    }
}

public interface IMultiplicationService
{
    double Multiply(int value, double factor);
}

public class MultiplicationService : IMultiplicationService
{
    public double Multiply(int value, double factor)
    {
        return value * factor;
    }
}

public class MathService
{
    private readonly ISumService _sumService;
    private readonly IMultiplicationService _multiplicationService;

    public MathService(
        ISumService sumService, 
        IMultiplicationService multiplicationService)
    {
        _sumService = sumService;
        _multiplicationService = multiplicationService;
    }

    public double GetMeanValue(params int[] values)
    {
        if (values.Length == 0)
        {
            throw new InvalidOperationException("Cannot divide by zero");
        }
        
        var sum = _sumService.Add(values);
        var divideByTwo = _multiplicationService.Multiply(sum, 1.0 / values.Length);
        return divideByTwo;
    }
}