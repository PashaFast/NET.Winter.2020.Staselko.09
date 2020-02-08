using System;
using Algorithms.V3.Interfaces;

namespace Algorithms.V3.GcdImplementations
{
    /// <summary>
    /// Class EuclideanAlgorithm.
    /// </summary>
    public class EuclideanAlgorithm : IAlgorithm
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

            first = Math.Abs(first);
            second = Math.Abs(second);
            if (first == 0)
            {
                return second;
            }

            return this.Calculate(second % first, first);
        }
    }
}