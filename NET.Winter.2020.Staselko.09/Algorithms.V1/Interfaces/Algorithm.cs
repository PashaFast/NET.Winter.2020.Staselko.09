using System;
using System.Diagnostics;

namespace Algorithms.V1.Interfaces
{
    /// <summary>
    /// Abstract class Algorithm.
    /// </summary>
    internal abstract class Algorithm
    {
        /// <summary>
        /// method for finding GCD of two numbers.
        /// </summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Gcd of numbers.</returns>
        public int Calculate(int first, int second)
        {
            if ((first == 0) && (second == 0))
            {
                throw new ArgumentException("Two numbers cannot be 0 at the same time.");
            }

            if (first == int.MinValue || second == int.MinValue)
            {
                throw new ArgumentException("Numbers cannot to be int.MinValue.");
            }

            return this.Func(first, second);
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

            int result = this.Func(first, second);

            stopwatch.Stop();
            milliseconds = stopwatch.ElapsedTicks;

            return result;
        }

        /// <summary>
        /// method for finding GCD of two numbers.
        /// </summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Gcd of numbers.</returns>
        protected abstract int Func(int first, int second);
    }
}