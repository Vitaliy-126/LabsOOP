using System;
namespace Shapes
{
    public class Shape
    {
        public Shape()
        {

        }
        public Shape(Point[]points)
        {
            quantityPoints = points.Length;
            for(int i = 0; i < quantityPoints; i++)
            {
                this.points[i] = points[i];
            }
        }
        public int QuantityPoints
        {
            get
            {
                if (quantityPoints > 0)
                {
                    return quantityPoints;
                }
                else
                {
                    throw new Exception("quantity of points must be greater than 0");
                }
            }
        }
        public Point[] Points
        {
            get
            {
                return points;
            }
        }
        public double SideLength(in Point left, in Point right)
        {
            return Math.Sqrt((right.X - left.X) + (right.Y - left.Y));
        }
        protected int quantityPoints;
        protected Point[] points;
    }
}
