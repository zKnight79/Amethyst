using System;

namespace Amethyst.Math
{
    /// <summary>
    /// Represents a size, for 2D elements
    /// </summary>
    public struct Size
    {
        /// <summary>
        /// The width component of the size
        /// </summary>
        public float Width;
        /// <summary>
        /// The height component of the size
        /// </summary>
        public float Height;

        /// <summary>
        /// Creates a new size by specifying width and height
        /// </summary>
        /// <param name="width">Width component</param>
        /// <param name="height">Height component</param>
        public Size(float width, float height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Add 2 Sizes
        /// </summary>
        /// <param name="a">Left operand</param>
        /// <param name="b">Right operand</param>
        /// <returns>a + b, as a new Size</returns>
        public static Size operator +(Size a, Size b)
        {
            return new Size(a.Width + b.Width, a.Height + b.Height);
        }
        /// <summary>
        /// Subtract 2 Sizes
        /// </summary>
        /// <param name="a">Left operand</param>
        /// <param name="b">Right operand</param>
        /// <returns>a - b, as a new Size</returns>
        public static Size operator -(Size a, Size b)
        {
            return new Size(a.Width - b.Width, a.Height - b.Height);
        }
        /// <summary>
        /// Multiply a Size by a floating number
        /// </summary>
        /// <param name="a">The Size</param>
        /// <param name="b">The floating number</param>
        /// <returns>a*b (a.Width*b, a.Height*b), as a new Size</returns>
        public static Size operator *(Size a, float b)
        {
            return new Size(a.Width * b, a.Height * b);
        }
        /// <summary>
        /// Divide a Size by a floating number
        /// </summary>
        /// <param name="a">The Size</param>
        /// <param name="b">The floating number</param>
        /// <returns>a/b (a.Width/b, a.Height/b), as a new Size</returns>
        public static Size operator /(Size a, float b)
        {
            return new Size(a.Width / b, a.Height / b);
        }
    }
}
