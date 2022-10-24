using System.ComponentModel;
using System.Linq;

namespace DWD.UnitTesting;

public interface ISumService
{
    int Add(params int[] values);
}

public class SumService : ISumService
{
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

    public int GetMeanValue(params int[] values)
    {
        var sum = _sumService.Add(values);
        var divideByTwo = _multiplicationService.Multiply(sum, 1.0 / values.Length);
        return (int) divideByTwo;
    }
}