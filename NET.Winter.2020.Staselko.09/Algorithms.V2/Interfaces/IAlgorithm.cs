namespace Algorithms.V2.Interfaces
{
    /// <summary>
    /// inteerface IAlgorithm.
    /// </summary>
    public interface IAlgorithm
    {
        /// <summary>
        /// Calculate method.
        /// </summary>
        /// <param name="first">first number.</param>
        /// <param name="second">second number.</param>
        /// <returns>Gcd of two numbers.</returns>
        int Calculate(int first, int second);
    }
}