using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public double Accumulator { get; set; } = 0;

        public double Add(double a, double b)
        {
            Accumulator = 0;
            Accumulator = a + b;
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            Accumulator = 0;
            Accumulator = a - b;
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            Accumulator = 0;
            Accumulator = a * b;
            return a * b;
        }

        public double Power(double x, double exp)
        {
            Accumulator = 0;
            Accumulator = Math.Pow(x, exp);
            return Math.Pow(x, exp);
        }

        public double Divide(double dividend, double divisor)
        {
            if (dividend == 0 || divisor == 0)
                throw new System.DivideByZeroException("Attempted divide by zero");
                return dividend / divisor;
        }

        public double Add(double addend)
        {
            return Accumulator+ addend;
        }

        public double newSubtract(double subtractor)
        {
            return Accumulator - subtractor;
        }

        public double newMultiply(double multiplier)
        {
            return Accumulator * multiplier;
        }

        //public double newDivide(double divisor)
        //{

        //}

        public double newPower(double exponent)
        {
            return Math.Pow(Accumulator, exponent);
        }

        public void Clear()
        {
            Accumulator = 0; 
        }

    }
}
