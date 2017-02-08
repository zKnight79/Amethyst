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

        /// <summary>
        /// Compute the sine of a angle in degrees
        /// </summary>
        /// <param name="angle">An angle in degrees</param>
        /// <returns>The sine of the angle</returns>
        public static float Sin(float angle)
        {
            return (float)System.Math.Sin(angle * DEG2RAD);
        }

        /// <summary>
        /// Compute the cosine of a angle in degrees
        /// </summary>
        /// <param name="angle">An angle in degrees</param>
        /// <returns>The cosine of the angle</returns>
        public static float Cos(float angle)
        {
            return (float)System.Math.Cos(angle * DEG2RAD);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        public static bool NearlyEquals(float a, float b, float epsilon=0.000001f)
        {
            if (a == b)
            {
                return true;
            }

            float diff = System.Math.Abs(a - b);
            if (a == 0 || b == 0 || diff < float.Epsilon)
            {
                return diff < epsilon;
            }
            //return diff / Math.min((absA + absB), Float.MAX_VALUE) < epsilon
            return (diff / (System.Math.Abs(a) + System.Math.Abs(b))) < epsilon;
        }
    }
}
