namespace DWD.DependencyInjection;

public interface IMathService
{
    double Sum(double a, double b);
    double Subtract(double a, double b);

    void SetValue(int value);
    int GetValue();
}