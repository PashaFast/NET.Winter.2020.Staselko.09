using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Algorithms.V2.Interfaces
{
    /// <summary>
    /// Class AlgorithmExtension.
    /// </summary>
    public static class AlgorithmExtension
    {
        #region Euclidean Algorithms (API)

        /// <summary>
        /// method for finding GCD of three numbers.
        /// </summary>
        /// <param name="algorithm">algorithm.</param>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <param name="third">Third number.</param>
        /// <returns>Gcd of numbers.</returns>
        public static int Calculate(this IAlgorithm algorithm, int first, int second, int third)
        {
            CheckValues(first, second, third);
            int temp;
            if (first == 0 && second == 0)
            {
                temp = 0;
            }
            else
            {
                temp = algorithm.Calculate(first, second);
            }

            return algorithm.Calculate(temp, third);
        }

        /// <summary>
        /// method for finding GCD of three numbers and time of working.
        /// </summary>
        /// <param name="algorithm">algorithm.</param>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <param name="milliseconds">time of working.</param>
        /// <returns>Gcd of numbers.</returns>
        public static int Calculate(this IAlgorithm algorithm, int first, int second, out long milliseconds)
        {
            if ((first == 0) && (second == 0))
            {
                throw new ArgumentException("Two numbers cannot be 0 at the same time.");
            }

            if (first == int.MinValue || second == int.MinValue)
            {
                throw new ArgumentException("Numbers cannot to be int.MinValue.");
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int result = algorithm.Calculate(first, second);

            stopwatch.Stop();
            milliseconds = stopwatch.ElapsedTicks;

            return result;
        }

        /// <summary>
        /// method for finding GCD of three numbers and time of working.
        /// </summary>
        /// <param name="algorithm">algorithm.</param>
        /// <param name="milliseconds">time of working.</param>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <param name="third">Third number.</param>
        /// <returns>Gcd of numbers.</returns>
        public static int Calculate(this IAlgorithm algorithm, out long milliseconds, int first, int second, int third)
        {
            CheckValues(first, second, third);
            int temp;
            long localMilliseconds;
            milliseconds = 0;
            if (first == 0 && second == 0)
            {
                temp = 0;
            }
            else
            {
                temp = algorithm.Calculate(first, second, out localMilliseconds);
                milliseconds += localMilliseconds;
            }

            return algorithm.Calculate(temp, third);
        }

        /// <summary>
        /// method for finding GCD of array of numbers.
        /// </summary>
        /// <param name="algorithm">algorithm.</param>
        /// <param name="numbers">Array of numbers.</param>
        /// <returns>Gcd.</returns>
        public static int Calculate(this IAlgorithm algorithm,  params int[] numbers)
        {
            CheckValues(numbers);
            int gcd = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 0)
                {
                    continue;
                }

                gcd = algorithm.Calculate(gcd, numbers[i]);
            }

            return gcd;
        }

        /// <summary>
        /// method for finding GCD of array of numbers and time of working.
        /// </summary>
        /// <param name="algorithm">algorithm.</param>
        /// <param name="milliseconds">time of working.</param>
        /// <param name="numbers">array of numbers.</param>
        /// <returns>Gcd.</returns>
        public static int Calculate(this IAlgorithm algorithm, out long milliseconds, params int[] numbers)
        {
            CheckValues(numbers);
            long localMilliseconds;
            milliseconds = 0;
            int gcd = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 0)
                {
                    continue;
                }

                gcd = algorithm.Calculate(gcd, numbers[i], out localMilliseconds);
                milliseconds += localMilliseconds;
            }

            return gcd;
        }

        #endregion

        #region CheckValues

        private static void CheckValues(int first, int second, int third)
        {
            if (first == 0 && second == 0 && third == 0)
            {
                throw new ArgumentException("Two numbers cannot be 0 at the same time.");
            }

            if (first == int.MinValue || second == int.MinValue || third == int.MinValue)
            {
                throw new ArgumentException("Numbers cannot to be int.MinValue.");
            }
        }

        private static void CheckValues(params int[] numbers)
        {
            int bad = 0;
            bool flag = false;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == int.MinValue)
                {
                    flag = true;
                }

                if (numbers[i] == 0)
                {
                    bad++;
                }
            }

            if (bad == numbers.Length)
            {
                throw new ArgumentException("Two numbers cannot be 0 at the same time.");
            }

            if (flag)
            {
                throw new ArgumentException("Numbers cannot to be int.MinValue.");
            }
        }
        #endregion
    }
}
