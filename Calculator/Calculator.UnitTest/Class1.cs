using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

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
            public void Power_AAndB_returnsResult(double x, double exp, double result)
            {
                Assert.That(uut.Power(x, exp), Is.EqualTo(result));
            }

            [TestCase(2, 64)]
            [TestCase(3, 512)]
            public void newPower_AAndB_returnsResult(double exp, double result)
            {
                uut.Accumulator = 8;
                Assert.That(uut.newPower(exp), Is.EqualTo(result));
            }

        }
    }
}
