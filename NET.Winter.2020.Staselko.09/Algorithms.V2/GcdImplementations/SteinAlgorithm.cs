using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.V2.Interfaces;

namespace Algorithms.V2.GcdImplementations
{
    /// <summary>
    /// Class SteinAlgoritm.
    /// </summary>
    public class SteinAlgoritm : IAlgorithm
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
                    return this.Calculate(first >> 1, second);
                }
                else
                {
                    return this.Calculate(first >> 1, second >> 1) << 1;
                }
            }

            if ((~second & 1) == 1)
            {
                return this.Calculate(first, second >> 1);
            }

            if (first > second)
            {
                return this.Calculate((first - second) >> 1, second);
            }

            return this.Calculate((second - first) >> 1, first);
        }
    }
}
