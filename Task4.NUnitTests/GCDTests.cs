using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task4;

namespace Task4.NUnitTests
{
    [TestFixture]
    public class GCDTests
    {
        [TestCase(24, 16, Result = 8)]
        public int FindGCDTest_ForTwoNumbersEuclid(int first, int second)
        {
            long time = 0;
            int result = GCD.FindGCD(out time, GCD.EuclidCalculation, first, second);
            return result;
        }

        [TestCase(24, 16, Result = 8)]
        public int FindGCDTest_ForTwoNumbersStein(int first, int second)
        {
            long time = 0;
            int result = GCD.FindGCD(out time, GCD.SteinCalculation, first, second);
            return result;
        }

        [TestCase(24, 16, 48, Result = 8)]
        [TestCase(8, ExpectedException = typeof(ArgumentException))]
        public int FindGCDTest_ForManyNumbersEuclid(params int[] numbers)
        {
            long time = 0;
            int result = GCD.FindGCD(out time, GCD.EuclidCalculation, numbers);
            return result;
        }

        [TestCase(24, 16, 48, Result = 8)]
        [TestCase(8, ExpectedException = typeof(ArgumentException))]
        public int FindGCDTest_ForManyNumbersStein(params int[] numbers)
        {
            long time = 0;
            int result = GCD.FindGCD(out time, GCD.SteinCalculation, numbers);
            return result;
        }
    }
}
