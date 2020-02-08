using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Algorithms.V3.Interfaces;

namespace Algorithms.V3.GcdImplementations
{
    /// <summary>
    /// Class Algorithm.
    /// </summary>
    public class Algorithm : IAlgorithm
    {
        private IAlgorithm algorithm;

        /// <summary>
        /// Initializes a new instance of the <see cref="Algorithm"/> class.
        /// Constructor.
        /// </summary>
        /// <param name="algorithm">any algoritm for computing.</param>
        public Algorithm(IAlgorithm algorithm)
        {
            this.algorithm = algorithm;
        }

        /// <summary>
        /// method for finding GCD of two numbers.
        /// </summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Gcd of numbers.</returns>
        public int Calculate(int first, int second)
        {
            return this.algorithm.Calculate(first, second);
        }

        /// <summary>
        ///  method for finding GCD of two numbers and time of working.
        /// </summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <param name="milliseconds">time of working.</param>
        /// <returns>Gcd of numbers.</returns>
        public int Calculate(int first, int second, out long milliseconds)
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

            int result = this.algorithm.Calculate(first, second);

            stopwatch.Stop();
            milliseconds = stopwatch.ElapsedTicks;

            return result;
        }

        /// <summary>
        /// method for finding GCD of three numbers.
        /// </summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <param name="third">Third number.</param>
        /// <returns>Gcd of numbers.</returns>
        public int Calculate(int first, int second, int third)
        {
            CheckValues(first, second, third);
            int temp;
            if (first == 0 && second == 0)
            {
                temp = 0;
            }
            else
            {
                temp = this.algorithm.Calculate(first, second);
            }

            return this.algorithm.Calculate(temp, third);
        }

        /// <summary>
        /// method for finding GCD of three numbers and time of working.
        /// </summary>
        /// <param name="milliseconds">time of working.</param>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <param name="third">Third number.</param>
        /// <returns>Gcd of numbers.</returns>
        public int Calculate(out long milliseconds, int first, int second, int third)
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
                temp = this.Calculate(first, second, out localMilliseconds);
                milliseconds += localMilliseconds;
            }

            return this.algorithm.Calculate(temp, third);
        }

        /// <summary>
        /// method for finding GCD of array of numbers.
        /// </summary>
        /// <param name="numbers">Array of numbers.</param>
        /// <returns>Gcd.</returns>
        public int Calculate(params int[] numbers)
        {
            CheckValues(numbers);
            int gcd = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 0)
                {
                    continue;
                }

                gcd = this.algorithm.Calculate(gcd, numbers[i]);
            }

            return gcd;
        }

        /// <summary>
        /// method for finding GCD of array of numbers and time of working.
        /// </summary>
        /// <param name="milliseconds">time of working.</param>
        /// <param name="numbers">array of numbers.</param>
        /// <returns>Gcd.</returns>
        public int Calculate(out long milliseconds, params int[] numbers)
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

                gcd = this.Calculate(gcd, numbers[i], out localMilliseconds);
                milliseconds += localMilliseconds;
            }

            return gcd;
        }

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
