using System;
namespace Shapes
{
    public class Triangle : Shape
    {
        public Triangle(Point[] points) : base(points,3)
        {
            
        }
        public double Perimeter()
        {
            double perimetr = SideLength(points[0], points[1]) + SideLength(points[0], points[2]) + SideLength(points[1], points[2]);
            return perimetr;
        }
        public double Square()
        {
            double halfPerimeter = Perimeter()/2;
            double square= Math.Sqrt(halfPerimeter*(halfPerimeter- SideLength(points[0], points[1]))*(halfPerimeter- SideLength(points[0], points[2]))*(halfPerimeter- SideLength(points[1], points[2])));
            return square;
        }
    }
}
