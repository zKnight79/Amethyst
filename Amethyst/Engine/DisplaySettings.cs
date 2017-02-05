using Amethyst.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amethyst.Engine
{
    public class DisplaySettings
    {
        /// <summary>
        /// Get or set the width of the game window (Default : 800)
        /// </summary>
        public int Width { get; set; } = 800;
        /// <summary>
        /// Get or set the Height of the game window (Default : 600)
        /// </summary>
        public int Height { get; set; } = 600;
        /// <summary>
        /// Get or set if the game should be run in Fullscreen (Default : false)
        /// </summary>
        public bool Fullscreen { get; set; } = false;
        /// <summary>
        /// Get or set the number of bits used for colors (Default : 32)
        /// </summary>
        public byte ColorBits { get; set; } = 32;
        /// <summary>
        /// Get or set the number of bits used for depth (Default : 0)
        /// </summary>
        public byte DepthBits { get; set; } = 0;
        /// <summary>
        /// Get or set the number of bits used for stencil (Default : 0)
        /// </summary>
        public byte StencilBits{ get; set; } = 0;
        /// <summary>
        /// Get or set the number of bits used for accum (Default : 0)
        /// </summary>
        public byte AccumBits { get; set; } = 0;
        /// <summary>
        /// Get or set the anti-aliasing level (Default : None)
        /// </summary>
        public AntiAliasingLevel MSAA { get; set; } = AntiAliasingLevel.None;

        public override string ToString()
        {
            return string.Format(
                @"DisplaySettings :
    - Width : {0}
    - Height : {1}
    - Fullscreen : {2}
    - ColorBits : {3}
    - DepthBits : {4}
    - StencilBits : {5}
    - AccumBits : {6}
    - MSAA : {7}",
                Width,
                Height,
                Fullscreen,
                ColorBits,
                DepthBits,
                StencilBits,
                AccumBits,
                MSAA
            );
        }
    }
}
