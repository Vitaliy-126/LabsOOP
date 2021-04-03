using System;
namespace Shapes
{
    public class Shape
    {
        public Shape()
        {

        }

        public Shape(Point[]points,int quantityPoints)
        {
            if (points.Length != quantityPoints)
            {
                throw new Exception("discrepancy in the number of points");
            }
            this.quantityPoints = quantityPoints;
            this.points = new Point[quantityPoints];
            for(int i = 0; i < quantityPoints; i++)
            {
                this.points[i] = points[i];
            }
        }

        public double SideLength(in Point left, in Point right)
        {
            return Math.Sqrt(Math.Pow((right.X - left.X),2) + Math.Pow((right.Y - left.Y),2));
        }

        protected int quantityPoints;
        protected Point[] points;
    }
}
