namespace Shapes
{
    public sealed class Point
    {
        public Point(double x,double y)
        {
            this.x = x;
            this.y = y;
        }
        public double X
        {
            get
            {
                return x;
            }
        }
        public double Y
        {
            get
            {
                return y;
            }
        }
        private double x;
        private double y;
    }
}
