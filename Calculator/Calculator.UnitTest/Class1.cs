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
            [TestCase(2.5, 2, 4.5)]
            public void Add_AAndB_returnsResult(double a, double b, double result)
            {
                Assert.That(uut.Add(a, b), Is.EqualTo(result).Within(0.01));
            }

            [TestCase(2, 2, 0)]
            [TestCase(-2, -2, 0)]
            [TestCase(2.5, 1.5, 1)]
            [TestCase(90, 20, 70)]
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

            [TestCase(2, 64)]
            [TestCase(3, 512)]
            public void newPower_AAndB_returnsResult(double exp, double result)
            {
                uut.Add(4, 4);
                Assert.That(uut.newPower(exp), Is.EqualTo(result));
            }

            [TestCase(6, 10)]
            [TestCase(12, 16)]
            public void newAdd_AAndB_returnsResult(double a, double result)
            {
                uut.Add(2, 2);
                Assert.That(uut.newAdd(a), Is.EqualTo(result));
            }

            [TestCase(6, -2)]
            [TestCase(12, -8)]
            public void newSubtract_AAndB_returnsResult(double a, double result)
            {
                uut.Add(2, 2);
                Assert.That(uut.newSubtract(a), Is.EqualTo(result));
            }


            [TestCase(6,  12)]
            [TestCase(12, 24)]
            public void newMultiply_AAndB_returnsResult(double a, double result)
            {
                uut.Subtract(4, 2);
                Assert.That(uut.newMultiply(a), Is.EqualTo(result));
            }

        }
    }
}
