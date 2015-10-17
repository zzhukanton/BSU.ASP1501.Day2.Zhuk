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
        [TestCase((long)0, 5, 125, Result = 5)]
        [TestCase((long)0, 0, 0, ExpectedException = typeof(ArgumentException))]
        [TestCase((long)0, 3, 7, Result = 1)]
        [TestCase((long)0, -17, 34, Result = 17)]
        [TestCase((long)0, 30, 0, Result = 30)]
        public int EuclidAlgorithm_TwoNumbers(out long time, int first, int second)
        {
            time = 0;

            int result = GCD.EuclidAlgorithm(out time, first, second);
            return result;
        }

        [TestCase((long)0, 5, 125, Result = 5)]
        [TestCase((long)0, 5, ExpectedException = typeof(ArgumentException))]
        [TestCase((long)0, 5, 125, 625, 400, Result = 5)]
        [TestCase((long)0, -5, 20, 60, Result = 5)]
        [TestCase((long)0, new int[] {}, ExpectedException = typeof(ArgumentException))]
        public int EuclidAlgorithm_ManyNumbers(out long time, params int[] numbers)
        {
            time = 0;

            int result = GCD.EuclidAlgorithm(out time, numbers);
            return result;
        }

        [TestCase((long)0, 5, 125, Result = 5)]
        [TestCase((long)0, 0, 125, Result = 125)]
        [TestCase((long)0, -5, 125, Result = 5)]
        [TestCase((long)0, 0, 0, ExpectedException = typeof(ArgumentException))]
        [TestCase((long)0, 5, 123, Result = 1)]
        public int SteinAlgorithm_TwoNumbers(out long time, int first, int second)
        {
            time = 0;

            int result = GCD.SteinAlgorithm(out time, first, second);
            return result;
        }

        [TestCase((long)0, 5, 125, Result = 5)]
        [TestCase((long)0, 5, ExpectedException = typeof(ArgumentException))]
        [TestCase((long)0, 5, 125, 625, 400, Result = 5)]
        [TestCase((long)0, -5, 20, 60, Result = 5)]
        [TestCase((long)0, new int[] { }, ExpectedException = typeof(ArgumentException))]
        public int SteinAlgorithm_ManyNumbers(out long time, params int[] numbers)
        {
            time = 0;

            int result = GCD.SteinAlgorithm(out time, numbers);
            return result;
        }
    }
}
