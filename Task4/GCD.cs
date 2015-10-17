using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task4
{
    /// <summary>
    /// Class for finding gcd
    /// </summary>
    public static class GCD
    {
        #region Euclid
        /// <summary>
        /// Euclid algorithm for two integers
        /// </summary>
        /// <param name="calculationTime">Calculation time for algorithm</param>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <returns>GCD</returns>
        public static int EuclidAlgorithm(out long calculationTime, int number1, int number2)
        {
            if (number1 == 0 && number2 == 0)
                throw new ArgumentException("Numbers are both zero");

            if (number1 < 0)
                number1 = Math.Abs(number1);

            if (number2 < 0)
                number2 = Math.Abs(number2);

            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (number2 != 0)
                number2 = number1 % (number1 = number2);
            timer.Stop();
            calculationTime = timer.ElapsedTicks;

            return number1;
        }

        /// <summary>
        /// Euclid algorithm for finding gcd for multiple numbers
        /// </summary>
        /// <param name="wholeTime">For save time to calculate</param>
        /// <param name="numbers">Numbers</param>
        /// <returns>GCD</returns>
        public static int EuclidAlgorithm(out long wholeTime, params int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException("Array is null");

            if (numbers.Length == 0 || numbers.Length == 1)
                throw new ArgumentException("Less than two numbers");

            int result = numbers[0];
            long time = 0;
            wholeTime = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (result == 1)
                    break;
                result = EuclidAlgorithm(out time, result, numbers[i + 1]);
                wholeTime += time;
            }

            return result;
        }
        #endregion

        #region Stein
        /// <summary>
        /// Stein algorithm for finding gcd
        /// </summary>
        /// <param name="time">Algorithm working time</param>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>GCD by Stein algorithm</returns>
        public static int SteinAlgorithm(out long time, int a, int b)
        {
            if (a == 0 && b == 0)
                throw new ArgumentException("Both numbers are zero");

            time = 0;
            Stopwatch timer = new Stopwatch();
            
            timer.Start();
            int result = SteinCalculation(a, b);
            timer.Stop();
            time = timer.ElapsedTicks;
            
            return result;
        }

        /// <summary>
        /// Stein algorithm for multiple integer numbers with time
        /// </summary>
        /// <param name="wholeTime">Algorithm working time</param>
        /// <param name="numbers">Numbers for gcd</param>
        /// <returns>GCD of many numbers</returns>
        public static int SteinAlgorithm(out long wholeTime, params int[] numbers)
        {
            if (numbers.Length == 0 || numbers.Length == 1)
                throw new ArgumentException("Less than two arguments");

            int result = numbers[0];
            long time = 0;
            wholeTime = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (result == 1)
                    break;
                result = SteinAlgorithm(out time, result, numbers[i + 1]);
                wholeTime += time;
            }

            return result;
        }

        /// <summary>
        /// Recursive Stein algorithm for gcd
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <returns>GCD</returns>
        private static int SteinCalculation(int number1, int number2)
        {
            if (number1 == 0)
                return number2;

            if (number2 == 0)
                return number1;

            if (number1 == number2)
                return number1;

            if (number1 == 1 || number2 == 1)
                return 1;

            if ((number1 % 2 == 0) && (number2 % 2 == 0))
                return 2 * SteinCalculation(number1 / 2, number2 / 2);

            if ((number1 % 2 == 0) && (number2 % 2 != 0))
                return SteinCalculation(number1 / 2, number2);

            if ((number1 % 2 != 0) && (number2 % 2 == 0))
                return SteinCalculation(number1, number2 / 2);

            return SteinCalculation(number2, Math.Abs(number1 - number2));
        }
        #endregion
    }
}
