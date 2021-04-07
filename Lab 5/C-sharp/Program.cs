using System;
using Shapes;
namespace C_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Point[] points = {
                new Point(3, 5) ,
                new Point(5, 6) ,
                new Point(0, 0)
            };
            Triangle triangle = new Triangle(points);
            Console.WriteLine("Периметр треугольника: {0:.##}", triangle.Perimeter());
            Console.WriteLine("Площадь треугольника: {0:.##}", triangle.Square());
            Console.WriteLine("Стороны треугольника: A({0:.##}) , B({1:.##}) , C({2:.##})",triangle.ASide,triangle.BSide,triangle.CSide);
            Console.WriteLine("Треугольник был создан с точок:");
            for(int i = 0; i < triangle.QuantityVertexes(); i++)
            {
                Console.WriteLine($"{triangle[i]}");
            }
            Console.ReadKey();
        }
    }
}
