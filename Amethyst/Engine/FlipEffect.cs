using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amethyst.Engine
{
    /// <summary>
    /// Flip effect used for Texture Drawing
    /// </summary>
    [Flags]
    public enum FlipEffect
    {
        /// <summary>
        /// No flip effect
        /// </summary>
        None = 0,
        /// <summary>
        /// Flip Horizontally
        /// </summary>
        Horizontally = 1,
        /// <summary>
        /// Flip Vertically
        /// </summary>
        Vertically = 2,
        /// <summary>
        /// Flip both Horizontally and Vertically
        /// </summary>
        Both = Horizontally | Vertically
    }
}
