﻿namespace Shapes
{
    public class Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Point(double x,double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X};{Y})";
        }
    }
}
