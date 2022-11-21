namespace DWD.BasicAPI.Services;

public interface IMathService
{
    double Sum(double a, double b);
    double Subtract(double a, double b);

    void SetValue(int value);
    int GetValue();
}

public class MathService : IMathService
{
    private readonly SumService _sumService;
    private readonly SubtractService _subtractService;

    private int _value = 0;

    public MathService(SumService sumService, SubtractService subtractService)
    {
        _sumService = sumService;
        _subtractService = subtractService;
    }

    public void SetValue(int value)
    {
        _value = value;
    }

    public int GetValue()
    {
        return _value;
    }

    public double Sum(double a, double b)
    {
        return _sumService.AddTwoDigits(a, b);
    }

    public double Subtract(double a, double b)
    {
        return _subtractService.SubtractTwoDigits(a, b);
    }
}

public class SubtractService
{
    public double SubtractTwoDigits(double a, double b)
    {
        return a - b;
    }
}

public class SumService
{
    public SumService()
    {
    
    }
    public double AddTwoDigits(double a, double b)
    {
        return a + b;
    }
}