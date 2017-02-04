using System;
using System.Collections.Generic;
using System.Text;

namespace Amethyst.Math
{
    /// <summary>
    /// Structure representing a 2D (float coords) point
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// X component of the coords
        /// </summary>
        public float X;
        /// <summary>
        /// Y component of the coords
        /// </summary>
        public float Y;

        /// <summary>
        /// Creates a new Point by explicitely setting its coords
        /// </summary>
        /// <param name="x">X component of the coords</param>
        /// <param name="y">Y component of the coords</param>
        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Add 2 Points
        /// </summary>
        /// <param name="a">Left operand</param>
        /// <param name="b">Right operand</param>
        /// <returns>a+b, as a new Point</returns>
        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
        /// <summary>
        /// Subtract 2 Points
        /// </summary>
        /// <param name="a">Left operand</param>
        /// <param name="b">Right operand</param>
        /// <returns>a-b, as a new Point</returns>
        public static Point operator -(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }
        /// <summary>
        /// Multiply a Point by a floating number
        /// </summary>
        /// <param name="a">Left operand</param>
        /// <param name="b">Right operand</param>
        /// <returns>a*b (a.X*b, a.Y*b), as a new Point</returns>
        public static Point operator *(Point a, float b)
        {
            return new Point(a.X * b, a.Y * b);
        }
        /// <summary>
        /// Divide a Point by a floating number
        /// </summary>
        /// <param name="a">Left operand</param>
        /// <param name="b">Right operand</param>
        /// <returns>a/b (a.X/b, a.Y/b), as a new Point</returns>
        public static Point operator /(Point a, float b)
        {
            return new Point(a.X / b, a.Y / b);
        }
        /// <summary>
        /// Add a Point and a Size
        /// </summary>
        /// <param name="p">The Point</param>
        /// <param name="s">The Size</param>
        /// <returns>p+s (p.X+s.Width, p.Y+s.Height), as a new Point</returns>
        public static Point operator +(Point p, Size s)
        {
            return new Point(p.X + s.Width, p.Y + s.Height);
        }
        /// <summary>
        /// Subtract a Size from a Point
        /// </summary>
        /// <param name="p">The Point</param>
        /// <param name="s">The Size</param>
        /// <returns>p-s (p.X-s.Width, p.Y-s.Height), as a new Point</returns>
        public static Point operator -(Point p, Size s)
        {
            return new Point(p.X - s.Width, p.Y - s.Height);
        }
        
        /// <summary>
        /// A Point with X=0 and Y=0 
        /// </summary>
        public static readonly Point Zero = new Point(0, 0);
    }
}
