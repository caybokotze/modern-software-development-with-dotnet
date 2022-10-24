namespace DWD.SolidPrinciples;

public class OpenClosed
{
    #region The darkness
    
    public class AreaCalculator {
        private Shape _shape;
        public AreaCalculator(Shape shape) {
            _shape = shape;
        }
    
        public double CalculateArea() {
            if (_shape.Type == "circle") {
                return Math.PI * (_shape.Diameter/2) * (_shape.Diameter/2);
            }
        
            if (_shape.Type == "square") {
                return _shape.Height * _shape.Width;
            }

            return 0;
        }
    }
    
    public class Shape {
        public string? Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Diameter { get; set; }
    }

    #endregion

    #region The light
    
    public interface IShape {
        double CalculateArea();
    }

    public class Square : IShape {
        public int Width { get; set; }
        public int Height { get; set; }
    
        public double CalculateArea() {
            return Width * Height;    
        }
    }

    public class Circle : IShape {
        public int Diameter { get; set; }
        public double CalculateArea() {
            return Math.PI * (Diameter / 2) * (Diameter / 2);
        }
    }

    public class BetterAreaCalculator {
        
        public double CalculateArea(IShape shape)
        {
            return shape.CalculateArea();
        }
    }
    

    #endregion
}