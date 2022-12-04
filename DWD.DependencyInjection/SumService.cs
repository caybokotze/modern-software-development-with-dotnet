namespace DWD.DependencyInjection;

public class SumService
{
    private readonly string _name;
    private readonly int _version;

    public SumService(string name, int version)
    {
        _name = name;
        _version = version;
    }
    public double AddTwoDigits(double a, double b)
    {
        return a + b;
    }
}