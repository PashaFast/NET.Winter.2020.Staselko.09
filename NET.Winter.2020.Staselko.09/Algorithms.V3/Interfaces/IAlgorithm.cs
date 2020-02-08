namespace Algorithms.V3.Interfaces
{
    /// <summary>
    /// Interface IAlgorithm.
    /// </summary>
    public interface IAlgorithm
    {
        /// <summary>
        /// method for finding GCD of two numbers.
        /// </summary>
        /// <param name="first">First number.</param>
        /// <param name="second">Second number.</param>
        /// <returns>Gcd of numbers.</returns>
        int Calculate(int first, int second);
    }
}