using System;

namespace Amethyst.Math
{
    /// <summary>
    /// A placeholder for mathematical helper functions
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Get PI value
        /// </summary>
        public const double PI = 3.141592653589793238462643383279502884197169399375105820974944592307816406286208998628034825342117067;
        /// <summary>
        /// Get the pre-computed value of 2PI
        /// </summary>
        public const double TWOPI = PI * 2.0;
        /// <summary>
        /// Get the pre-computed value of PI/2
        /// </summary>
        public const double HALFPI = PI / 2.0;
        /// <summary>
        /// Get Degree to Radian convertion factor
        /// </summary>
        public const double DEG2RAD = PI / 180;
        /// <summary>
        /// Get Radian to Degree convertion factor
        /// </summary>
        public const double RAD2DEG = 180 / PI;
        
        /// <summary>
        /// Clamp a value between 2 values
        /// </summary>
        /// <param name="val">Value to clamp</param>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns>The value clamped between min and max</returns>
        public static float Clamp(float val, float min, float max)
        {
            return System.Math.Max(min, System.Math.Min(max, val));
        }

        /// <summary>
        /// Swap the values of 2 variables
        /// </summary>
        /// <typeparam name="T">Type of values</typeparam>
        /// <param name="a">A variable of type T</param>
        /// <param name="b">Another variable of type T</param>
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
