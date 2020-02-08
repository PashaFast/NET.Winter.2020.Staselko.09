using System;
using Algorithms.V1.Interfaces;

namespace Algorithms.V1.GcdImplementations
{
    /// <summary>
    /// Class EuclideanAlgorithm.
    /// </summary>
    internal class EuclideanAlgorithm : Algorithm
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
            if (first == 0)
            {
                return second;
            }

            return this.Func(second % first, first);
        }
    }
}