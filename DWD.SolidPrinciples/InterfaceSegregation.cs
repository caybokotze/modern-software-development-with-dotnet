namespace DWD.SolidPrinciples;

#region The darkness
public interface IShapeInterface
{
    double CalculateArea();
    double CalculateVolume();
}

public class Square : IShapeInterface
{
    private readonly int _width;

    public Square(int width)
    {
        _width = width;
    }
    
    public double CalculateArea()
    {
        return _width * _width;
    }

    public double CalculateVolume()
    {
        // i.e. Not possible
        throw new NotImplementedException();
    }
}
#endregion

#region The light
public interface I2DShape
{
    double CalculateArea();
}

public interface I3DShape : I2DShape
{
    double CalculateVolume();
}

public class Rectangle : I2DShape
{
    private readonly int _height;
    private readonly int _width;

    public Rectangle(int height, int width)
    {
        _height = height;
        _width = width;
    }
    
    public double CalculateArea()
    {
        return _height * _width;
    }
}

public class Cube : I3DShape
{
    private readonly int _width;

    public Cube(int width)
    {
        _width = width;
    }
    
    public double CalculateVolume()
    {
        return _width * _width * _width;
    }

    public double CalculateArea()
    {
        const int amountOfEdges = 6;
        return _width * _width * amountOfEdges;
    }
}
#endregion

