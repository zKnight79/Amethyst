using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amethyst.Engine
{
    /// <summary>
    /// Text alignment options
    /// </summary>
    [Flags]
    public enum TextAlign
    {
        /// <summary>
        /// Left horizontal alignment
        /// </summary>
        Left = 0,
        /// <summary>
        /// Centered horizontally
        /// </summary>
        Center = 1,
        /// <summary>
        /// Right horizontal alignment
        /// </summary>
        Right = 2,
        /// <summary>
        /// Top vertical alignment
        /// </summary>
        Top = 0,
        /// <summary>
        /// Centered vertically
        /// </summary>
        Middle = 4,
        /// <summary>
        /// Bottom vertical alignment
        /// </summary>
        Bottom = 8,
        /// <summary>
        /// Top + Left
        /// </summary>
        TopLeft = Top | Left,
        /// <summary>
        /// Top + Center
        /// </summary>
        TopCenter = Top | Center,
        /// <summary>
        /// Top + Right
        /// </summary>
        TopRight = Top | Right,
        /// <summary>
        /// Middle + Left
        /// </summary>
        MiddleLeft = Middle | Left,
        /// <summary>
        /// Middle + Center
        /// </summary>
        MiddleCenter = Middle | Center,
        /// <summary>
        /// Middle + Right
        /// </summary>
        MiddleRight = Middle | Right,
        /// <summary>
        /// Bottom + Left
        /// </summary>
        BottomLeft = Bottom | Left,
        /// <summary>
        /// Bottom + Center
        /// </summary>
        BottomCenter = Bottom | Center,
        /// <summary>
        /// Bottom + Right
        /// </summary>
        BottomRight = Bottom | Right
    }
}
