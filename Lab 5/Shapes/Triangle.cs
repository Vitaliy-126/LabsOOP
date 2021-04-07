using System;
namespace Shapes
{
    public class Triangle : Shape
    {
        public double ASide { get; private set; }
        public double BSide { get; private set; }
        public double CSide { get; private set; }
        public Triangle(Point[] points) : base(points,3)
        {
            ASide = SideLength(points[0], points[1]);
            BSide = SideLength(points[0], points[2]);
            CSide = SideLength(points[1], points[2]);
            if (ASide + BSide <= CSide || ASide + CSide <= BSide || BSide + CSide <= ASide)
            {
                throw new Exception("such a triangle does not exist");
            }
        }
        public override double Perimeter()
        {
            return ASide + BSide + CSide;
        }
        public override double Square()
        {
            double halfPerimeter = Perimeter()/2;
            double square= Math.Sqrt(halfPerimeter*(halfPerimeter- ASide)*(halfPerimeter- BSide)*(halfPerimeter- CSide));
            return square;
        }
    }
}
