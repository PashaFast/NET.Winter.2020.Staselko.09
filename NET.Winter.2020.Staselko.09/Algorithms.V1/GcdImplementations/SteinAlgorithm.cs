using System;
using Algorithms.V1.Interfaces;

namespace Algorithms.V1.GcdImplementations
{
    /// <summary>
    /// Class SteinAlgorithm.
    /// </summary>
    internal class SteinAlgorithm : Algorithm
    {
        /// <summary>
        /// method for finding GCD of two numbers.
        /// </summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Gcd of numbers.</returns>
        protected override int Func(int first, int second)
        {
            first = Math.Abs(first);
            second = Math.Abs(second);
            if (first == second)
            {
                return first;
            }

            if (first == 0)
            {
                return second;
            }

            if (second == 0)
            {
                return first;
            }

            if ((~first & 1) == 1)
            {
                if ((second & 1) == 1)
                {
                    return this.Func(first >> 1, second);
                }
                else
                {
                    return this.Func(first >> 1, second >> 1) << 1;
                }
            }

            if ((~second & 1) == 1)
            {
                return this.Func(first, second >> 1);
            }

            if (first > second)
            {
                return this.Func((first - second) >> 1, second);
            }

            return this.Func((second - first) >> 1, first);
        }
    }
}
