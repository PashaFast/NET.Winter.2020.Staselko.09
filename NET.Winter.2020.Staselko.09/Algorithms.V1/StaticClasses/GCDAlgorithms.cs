using System;
using Algorithms.V1.GcdImplementations;
using Algorithms.V1.Interfaces;

namespace Algorithms.V1.StaticClasses
{
    /// <summary>
    /// Class GCDAlgorithms.
    /// </summary>
    public static class GCDAlgorithms
    {
        #region Stein Algorithms (API)

        /// <summary>
        /// method for finding GCD of two numbers.
        /// </summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Gcd of numbers.</returns>
        public static int FindGcdByStein(int first, int second)
                    => Gcd(first, second, new SteinAlgorithm());

        /// <summary>
        ///  method for finding GCD of two numbers and time of working.
        /// </summary>
        /// <param name="milliseconds">time of working.</param>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Gcd of numbers.</returns>
        public static int FindGcdByStein(out long milliseconds, int first, int second)
            => Gcd(first, second, out milliseconds, new SteinAlgorithm());

        /// <summary>
        /// method for finding GCD of three numbers.
        /// </summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <param name="third">Third number.</param>
        /// <returns>Gcd of numbers.</returns>
        public static int FindGcdByStein(int first, int second, int third)
            => Gcd(first, second, third, new SteinAlgorithm());

        /// <summary>
        /// method for finding GCD of three numbers and time of working.
        /// </summary>
        /// <param name="milliseconds">time of working.</param>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <param name="third">Third number.</param>
        /// <returns>Gcd of numbers.</returns>
        public static int FindGcdByStein(out long milliseconds, int first, int second, int third)
            => Gcd(first, second, third, out milliseconds, new SteinAlgorithm());

        /// <summary>
        /// method for finding GCD of array of numbers.
        /// </summary>
        /// <param name="numbers">Array of numbers.</param>
        /// <returns>Gcd.</returns>
        public static int FindGcdByStein(params int[] numbers)
            => Gcd(new SteinAlgorithm(), numbers);

        /// <summary>
        /// method for finding GCD of array of numbers and time of working.
        /// </summary>
        /// <param name="milliseconds">time of working.</param>
        /// <param name="numbers">array of numbers.</param>
        /// <returns>Gcd.</returns>
        public static int FindGcdByStein(out long milliseconds, params int[] numbers)
            => Gcd(new SteinAlgorithm(), out milliseconds, numbers);

        #endregion
        #region Euclidean Algorithms (API)

        /// <summary>
        /// method for finding GCD of two numbers.
        /// </summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Gcd of numbers.</returns>
        public static int FindGcdByEuclidean(int first, int second)
                    => Gcd(first, second, new EuclideanAlgorithm());

        /// <summary>
        ///  method for finding GCD of two numbers and time of working.
        /// </summary>
        /// <param name="milliseconds">time of working.</param>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Gcd of numbers.</returns>
        public static int FindGcdByEuclidean(out long milliseconds, int first, int second)
            => Gcd(first, second, out milliseconds, new EuclideanAlgorithm());

        /// <summary>
        /// method for finding GCD of three numbers.
        /// </summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <param name="third">Third number.</param>
        /// <returns>Gcd of numbers.</returns>
        public static int FindGcdByEuclidean(int first, int second, int third)
            => Gcd(first, second, third, new EuclideanAlgorithm());

        /// <summary>
        /// method for finding GCD of three numbers and time of working.
        /// </summary>
        /// <param name="milliseconds">time of working.</param>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <param name="third">Third number.</param>
        /// <returns>Gcd of numbers.</returns>
        public static int FindGcdByEuclidean(out long milliseconds, int first, int second, int third)
            => Gcd(first, second, third, out milliseconds, new EuclideanAlgorithm());

        /// <summary>
        /// method for finding GCD of array of numbers.
        /// </summary>
        /// <param name="numbers">Array of numbers.</param>
        /// <returns>Gcd.</returns>
        public static int FindGcdByEuclidean(params int[] numbers)
            => Gcd(new EuclideanAlgorithm(), numbers);

        /// <summary>
        /// method for finding GCD of array of numbers and time of working.
        /// </summary>
        /// <param name="milliseconds">time of working.</param>
        /// <param name="numbers">array of numbers.</param>
        /// <returns>Gcd.</returns>
        public static int FindGcdByEuclidean(out long milliseconds, params int[] numbers)
            => Gcd(new EuclideanAlgorithm(), out milliseconds, numbers);

        #endregion

        #region Helper methods

        private static int Gcd(int first, int second, Algorithm algorithm)
            => algorithm.Calculate(first, second);

        private static int Gcd(int first, int second, out long milliseconds, Algorithm algorithm)
            => algorithm.Calculate(first, second, out milliseconds);

        private static int Gcd(int first, int second, int third, Algorithm algorithm)
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

        private static int Gcd(int first, int second, int third, out long milliseconds, Algorithm algorithm)
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

        private static int Gcd(Algorithm algorithm, params int[] numbers)
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

        private static int Gcd(Algorithm algorithm, out long milliseconds, params int[] numbers)
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