using System;
namespace C_sharp
{
    public class Expression
    {
        public Expression()
        {

        }
        public Expression(double a,double c,double d)
        {
            A = a;
            C = c;
            D = d;
        }
        public double GetValue()
        {
            if (D / 4 <= 0)
            {
                throw new ArithmeticException("The expression under the logarithm must be greater than zero");
            }
            else if (A * A - 1 == 0)
            {
                throw new DivideByZeroException("Division by zero occurred in the denominator");
            }
            return (2 * C - Math.Log10(D / 4)) / (A * A - 1);
        }
        public double A { get; set; }
        public double C { get; set; }
        public double D { get; set; }
        public override string ToString()
        {
            return "(2*c-lg(d/4))/(a*a-1)";
        }
    }
}
