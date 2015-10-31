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
        public delegate int GCDFindingMethod(int first, int second);

        /// <summary>
        /// Finds gcd of the selected method
        /// </summary>
        /// <param name="wholeTime">Working time</param>
        /// <param name="method">Method for finding gcd</param>
        /// <param name="numbers">List of numbers for finding gcd</param>
        /// <returns>GCD</returns>
        public static int FindGCD(out long wholeTime, GCDFindingMethod method, params int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException("Array is null");

            if (method == null)
                throw new ArgumentNullException("Method for finding gcd is not defined");

            if (numbers.Length == 0 || numbers.Length == 1)
                throw new ArgumentException("Less than two numbers");

            int result = numbers[0];
            wholeTime = 0;
            Stopwatch timer = new Stopwatch();

            timer.Start();
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (result == 1)
                    break;
                result = method(result, numbers[i + 1]);
            }
            timer.Stop();
            wholeTime = timer.ElapsedTicks;

            return result;
        }

        /// <summary>
        /// Finds gcd with selected method
        /// </summary>
        /// <param name="first">First number</param>
        /// <param name="second">Second number</param>
        /// <param name="wholeTime">Algorithm working time</param>
        /// <param name="method">Method for finding gcd</param>
        /// <returns>GCD of two numbers</returns>
        public static int FindGCD(int first, int second, out long wholeTime, GCDFindingMethod method)
        {
            if (method == null)
                throw new ArgumentNullException("Method for finding gcd is not defined");

            wholeTime = 0;
            Stopwatch timer = new Stopwatch();
            int result = 0;

            timer.Start();
            result = method(first, second);
            timer.Stop();
            wholeTime = timer.ElapsedTicks;

            return result;
        }

        /// <summary>
        /// Euclid algorithm for two numbers
        /// </summary>
        /// <param name="number1">One number</param>
        /// <param name="number2">Second number</param>
        /// <returns>GCD</returns>
        public static int EuclidCalculation(int number1, int number2)
        {
            if (number1 == 0 && number2 == 0)
                throw new ArgumentException("Numbers are both zero");

            if (number1 < 0)
                number1 = Math.Abs(number1);

            if (number2 < 0)
                number2 = Math.Abs(number2);

            while (number2 != 0)
                number2 = number1 % (number1 = number2);

            return number1;
        }

        /// <summary>
        /// Recursive Stein algorithm for gcd
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <returns>GCD</returns>
        public static int SteinCalculation(int number1, int number2)
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
    }
}
