using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amethyst.Math
{
    /// <summary>
    /// Extensions methods for Amethyst.Math
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Extension method for System.Drawing.Point, to convert it into an Amethyst Point
        /// </summary>
        /// <param name="point">A System.Drawing.Point</param>
        /// <returns>An Amethyst.Math.Point</returns>
        public static Point ToAmethystPoint(this System.Drawing.Point point)
        {
            return new Point(point.X, point.Y);
        }

        /// <summary>
        /// Extension method for System.Drawing.Size, to convert it into an Amethyst Size
        /// </summary>
        /// <param name="size">A System.Drawing.Size</param>
        /// <returns>An Amethyst.Math.Size</returns>
        public static Size ToAmethystSize(this System.Drawing.Size size)
        {
            return new Size(size.Width, size.Height);
        }
    }
}
