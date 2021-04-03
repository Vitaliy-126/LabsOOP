using System;
using Shapes;
namespace C_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Point point1 = new Point(3,5);
            Point point2 = new Point(5, 6);
            Point point3 = new Point(0, 0);
            Point[] points = { point1,point2,point3};

            Triangle triangle = new Triangle(points);
            Console.WriteLine("Периметр треугольника: {0:.##}", triangle.Perimeter());
            Console.WriteLine("Площадь треугольника: {0:.##}", triangle.Square());
            Console.ReadKey();
        }
    }
}
