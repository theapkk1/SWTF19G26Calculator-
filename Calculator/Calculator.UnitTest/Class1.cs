using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using DivideByZeroException = System.DivideByZeroException;

namespace Calculator.UnitTest
{
    public class Class1
    {
        [TestFixture]
        public class CalculatorUnitTest
        {
            private Calculator uut;

            [SetUp]
            public void Setup()
            {
                uut = new Calculator();
            }

            [TestCase(2, 2, 4)]
            [TestCase(-2, -2, -4)]
            [TestCase(2.5, 2.5, 5)]
            [TestCase(2.5, -2.5, 0)]
            public void Add_AAndB_returnsResult(double a, double b, double result)
            {
                Assert.That(uut.Add(a, b), Is.EqualTo(result).Within(0.01));
            }

            [TestCase(2, 2, 0)]
            [TestCase(-2, -2, 0)]
            [TestCase(2.5, 1.5, 1)]
            public void Subtract_AAndB_returnResult(double a, double b, double result)
            {
                Assert.That(uut.Subtract(a, b), Is.EqualTo(result));
            }

            [TestCase(3, 3, 9)]
            [TestCase(-3, 3, -9)]
            public void Multiply_AAndB_returnsResult(double a, double b, double result)
            {
                Assert.That(uut.Multiply(a, b), Is.EqualTo(result));
            }

            [TestCase(1, 3, 1)]
            [TestCase(-1, -3, -1)]
            public void Power_xAndexp_returnsResult(double x, double exp, double result)
            {
                Assert.That(uut.Power(x, exp), Is.EqualTo(result));
            }

            [TestCase(2, 2, 1)]
            [TestCase(-2, 2, -1)]
            public void Divide_dividendAnddivisor_returnsResult(double dividend, double divisor, double result)
            {
                Assert.That(uut.Divide(dividend, divisor), Is.EqualTo(result));
            }

            [Test]
            public void Divide_dividendAnddivisor_returnsException()
            {
                var ex = Assert.Catch<DivideByZeroException>(() => uut.Divide(0, 0));
                StringAssert.Contains("Attempted divide by zero", ex.Message);
                // Her testes det, at metoden smider en exception, hvis et af tallene er lig med 0 
            }

        }
    }
}
