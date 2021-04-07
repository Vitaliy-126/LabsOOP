using System;
namespace Shapes
{
    public abstract class Shape
    {
        public Shape(Point[]points,int quantityVertexes)
        {
            if (points.Length != quantityVertexes)
            {
                throw new Exception("discrepancy in the number of points");
            }
            this.quantityVertexes = quantityVertexes;
            this.points = new Point[quantityVertexes];
            for(int i = 0; i < quantityVertexes; i++)
            {
                this.points[i] = points[i];
            }
        }

        public static double SideLength(in Point left, in Point right)
        {
            return Math.Sqrt(Math.Pow((right.X - left.X),2) + Math.Pow((right.Y - left.Y),2));
        }

        public abstract double Perimeter();
        public abstract double Square();

        public int QuantityVertexes()
        {
            return quantityVertexes;
        }

        public Point this[int index]
        {
            get
            {
                if (index >= 0 && index < quantityVertexes)
                {
                    return points[index];
                }
                else
                {
                    throw new Exception("index out of range");
                }
            }
        }

        protected int quantityVertexes;
        protected Point[] points;
    }
}
