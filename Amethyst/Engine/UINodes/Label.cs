using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amethyst.Graphics;
using Amethyst.Math;

namespace Amethyst.Engine.UINodes
{
    /// <summary>
    /// A Label is an UINode that just render its text
    /// </summary>
    public class Label : UINode
    {
        /// <summary>
        /// Create a new instance of Label
        /// </summary>
        /// <param name="box">The Box where to render the Label</param>
        /// <param name="text">The Text of the Label</param>
        /// <param name="font">The Font used to render the Text of the Label</param>
        /// <param name="textColor">The Color of the Text of the Label</param>
        public Label(Box box, string text, Font font, Color4 textColor) : base(box, font)
        {
            Text = text;
            TextColor = textColor;
        }
    }
}
