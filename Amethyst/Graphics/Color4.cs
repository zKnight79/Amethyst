using System;
using System.Drawing;

using Amethyst.Math;

namespace Amethyst.Graphics
{
    /// <summary>
    /// Structure representing a RGBA color where components values goes from 0.0f to 1.0f
    /// </summary>
    public struct Color4
    {
        float m_Red;
        float m_Green;
        float m_Blue;
        float m_Alpha;

        /// <summary>
        /// Get or set Red component, clamped to [0.0f, 1.0f]
        /// </summary>
        public float Red
        {
            get { return m_Red; }
            set
            {
                m_Red = Helper.Clamp(value, 0.0f, 1.0f);
            }
        }
        /// <summary>
        /// Get or set Green component, clamped to [0.0f, 1.0f]
        /// </summary>
        public float Green
        {
            get { return m_Green; }
            set
            {
                m_Green = Helper.Clamp(value, 0.0f, 1.0f);
            }
        }
        /// <summary>
        /// Get or set Blue component, clamped to [0.0f, 1.0f]
        /// </summary>
        public float Blue
        {
            get { return m_Blue; }
            set
            {
                m_Blue = Helper.Clamp(value, 0.0f, 1.0f);
            }
        }
        /// <summary>
        /// Get or set Alpha component, clamped to [0.0f, 1.0f]
        /// </summary>
        public float Alpha
        {
            get { return m_Alpha; }
            set
            {
                m_Alpha = Helper.Clamp(value, 0.0f, 1.0f);
            }
        }

        /// <summary>
        /// Creates a new Color4 by specifying RGBA components
        /// </summary>
        /// <param name="red">Value for the Red component</param>
        /// <param name="green">Value for the Green component</param>
        /// <param name="blue">Value for the Blue component</param>
        /// <param name="alpha">Value for the Alpha component</param>
        public Color4(float red, float green, float blue, float alpha)
            : this()
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }
        /// <summary>
        /// Creates a new Color4 by specifying RGB components, Alpha will be set to 1 (opaque)
        /// </summary>
        /// <param name="red">Value for the Red component</param>
        /// <param name="green">Value for the Green component</param>
        /// <param name="blue">Value for the Blue component</param>
        public Color4(float red, float green, float blue) : this(red, green, blue, 1.0f) { }
        /// <summary>
        /// Creates a new grey Color4
        /// </summary>
        /// <param name="greyScale">The value that will be set to the Red, Green and Blue components</param>
        /// <param name="alpha">Value for the Alpha component</param>
        public Color4(float greyScale, float alpha) : this(greyScale, greyScale, greyScale, alpha) { }
        /// <summary>
        /// Creates a new grey Color4, with Alpha set to 1 (opaque)
        /// </summary>
        /// <param name="greyScale">The value that will be set to the Red, Green and Blue components</param>
        public Color4(float greyScale) : this(greyScale, 1.0f) { }
        /// <summary>
        /// Creates a new Color4 by specifying RGBA components in range [0, 255]
        /// </summary>
        /// <param name="red">Value for the Red component</param>
        /// <param name="green">Value for the Green component</param>
        /// <param name="blue">Value for the Blue component</param>
        /// <param name="alpha">Value for the Alpha component</param>
        public Color4(byte red, byte green, byte blue, byte alpha) : this(red / 255f, green / 255f, blue / 255f, alpha / 255f) { }
        /// <summary>
        /// Creates a new Color4 by specifying RGB components in range [0, 255], Alpha will be set to 255
        /// </summary>
        /// <param name="red">Value for the Red component</param>
        /// <param name="green">Value for the Green component</param>
        /// <param name="blue">Value for the Blue component</param>
        public Color4(byte red, byte green, byte blue) : this(red, green, blue, 255) { }
        /// <summary>
        /// Creates a new Color4 from a GDI Color and specifying Alpha component in range [0, 255]
        /// </summary>
        /// <param name="color">The reference GDI color</param>
        /// <param name="alpha">Value for the Alpha component</param>
        public Color4(Color color, byte alpha) : this(color.R, color.G, color.B, alpha) { }
        /// <summary>
        /// Creates a new Color4 from a GDI Color, Alpha will be set to 255
        /// </summary>
        /// <param name="color">The reference GDI color</param>
        public Color4(Color color) : this(color, 255) { }
        
        /// <summary>
        /// Multiply a Color4 by a scalar (only RGB components)
        /// </summary>
        /// <param name="color">A Color4</param>
        /// <param name="multiplier">A scalar</param>
        /// <returns>A new Color4</returns>
        public static Color4 operator *(Color4 color, float multiplier)
        {
            Color4 c = color;
            c.Red *= multiplier;
            c.Green *= multiplier;
            c.Blue *= multiplier;
            return c;
        }
        /// <summary>
        /// Divide a Color4 by a scalar (only RGB components)
        /// </summary>
        /// <param name="color">A Color4</param>
        /// <param name="divisor">A scalar</param>
        /// <returns>A new Color4</returns>
        public static Color4 operator /(Color4 color, float divisor)
        {
            Color4 c = color;
            c.Red /= divisor;
            c.Green /= divisor;
            c.Blue /= divisor;
            return c;
        }

        /// <summary>
        /// Computes a new color that is darker than this Color4, based on a coefficient
        /// </summary>
        /// <param name="coef">The coefficient of darkness, must be greater than 1</param>
        /// <returns>A new Color4</returns>
        public Color4 Darker(float coef)
        {
            return this / coef;
        }
        /// <summary>
        /// Computes a new color that is brighter than this Color4, based on a coefficient
        /// </summary>
        /// <param name="coef">The coefficient of brightness, must be greater than 1</param>
        /// <returns>A new Color4</returns>
        public Color4 Brighter(float coef)
        {
            if (m_Red == 0) { m_Red = 1f / 255f; }
            if (m_Green == 0) { m_Green = 1f / 255f; }
            if (m_Blue == 0) { m_Blue = 1f / 255f; }
            return this * coef;
        }
        /// <summary>
        /// Blend the color with the other color based on a ratio
        /// </summary>
        /// <param name="color">The color to blend the original color with</param>
        /// <param name="ratio">Must be less than 1</param>
        /// <returns>A new Color4, result of the blend</returns>
        public Color4 Blend(Color4 color, float ratio)
        {
            float inverseratio = 1 - ratio;
            return new Color4(this.Red * ratio + color.Red * inverseratio, this.Green * ratio + color.Green * inverseratio, this.Blue * ratio + color.Blue * inverseratio, this.Alpha);
        }
        /// <summary>
        /// Blend the color with the other color, with a 50/50 ratio
        /// </summary>
        /// <param name="color">The color to blend the original color with</param>
        /// <returns>A new Color4, result of the blend</returns>
        public Color4 Blend(Color4 color)
        {
            return this.Blend(color, 0.5f);
        }
        /// <summary>
        /// Invert the color (White => Black, Blue=>Yellow, ...) (only RGB components)
        /// </summary>
        /// <returns>A new Color4, invert of the original</returns>
        public Color4 Invert()
        {
            return new Color4(1 - m_Red, 1 - m_Green, 1 - m_Blue, m_Alpha);
        }
        /// <summary>
        /// Computes the distance from the Color4 to another Color4 (using only RGB components)
        /// </summary>
        /// <param name="color">The color to compare with the original</param>
        /// <returns>A float that represent the distance between the 2 Color4</returns>
        public float Distance(Color4 color)
        {
            float r = color.m_Red - m_Red;
            float g = color.m_Green - m_Green;
            float b = color.m_Blue - m_Blue;
            return (float)System.Math.Sqrt(r * r + g * g + b * b);
        }
        /// <summary>
        /// Creates a new color that is a copy of the selected color, specifying new alpha (0 to 1)
        /// </summary>
        /// <param name="alpha">The new alpha for the copy</param>
        /// <returns>A new Color4, with the specidied transparency</returns>
        public Color4 MakeTransparent(float alpha)
        {
            return new Color4(Red, Green, Blue, alpha);
        }
        /// <summary>
        /// Creates a new color that is a copy of the selected color, specifying new alpha (0 to 255)
        /// </summary>
        /// <param name="alpha">The new alpha for the copy</param>
        /// <returns>A new Color4, with the specidied transparency</returns>
        public Color4 MakeTransparent(byte alpha)
        {
            return this.MakeTransparent(alpha / 255f);
        }
        /// <summary>
        /// Get if the Color4 is dark or not
        /// </summary>
        public bool IsDark
        {
            get
            {
                float w = this.Distance(Colors.White);
                float b = this.Distance(Colors.Black);
                return b < w;
            }
        }

        #region PRE-DEFINED COLORS
        #pragma warning disable 1591
        /// <summary>
        /// A static class containing pre-defined Color4 colors
        /// </summary>
        public static class Colors
        {
            public static readonly Color4 AliceBlue = new Color4(Color.AliceBlue);
            public static readonly Color4 AntiqueWhite = new Color4(Color.AntiqueWhite);
            public static readonly Color4 Aqua = new Color4(Color.Aqua);
            public static readonly Color4 Aquamarine = new Color4(Color.Aquamarine);
            public static readonly Color4 Azure = new Color4(Color.Azure);
            public static readonly Color4 Beige = new Color4(Color.Beige);
            public static readonly Color4 Bisque = new Color4(Color.Bisque);
            public static readonly Color4 Black = new Color4(Color.Black);
            public static readonly Color4 BlanchedAlmond = new Color4(Color.BlanchedAlmond);
            public static readonly Color4 Blue = new Color4(Color.Blue);
            public static readonly Color4 BlueViolet = new Color4(Color.BlueViolet);
            public static readonly Color4 Brown = new Color4(Color.Brown);
            public static readonly Color4 BurlyWood = new Color4(Color.BurlyWood);
            public static readonly Color4 CadetBlue = new Color4(Color.CadetBlue);
            public static readonly Color4 Chartreuse = new Color4(Color.Chartreuse);
            public static readonly Color4 Chocolate = new Color4(Color.Chocolate);
            public static readonly Color4 Coral = new Color4(Color.Coral);
            public static readonly Color4 CornflowerBlue = new Color4(Color.CornflowerBlue);
            public static readonly Color4 Cornsilk = new Color4(Color.Cornsilk);
            public static readonly Color4 Crimson = new Color4(Color.Crimson);
            public static readonly Color4 Cyan = new Color4(Color.Cyan);
            public static readonly Color4 DarkBlue = new Color4(Color.DarkBlue);
            public static readonly Color4 DarkCyan = new Color4(Color.DarkCyan);
            public static readonly Color4 DarkGoldenrod = new Color4(Color.DarkGoldenrod);
            public static readonly Color4 DarkGray = new Color4(Color.DarkGray);
            public static readonly Color4 DarkGreen = new Color4(Color.DarkGreen);
            public static readonly Color4 DarkKhaki = new Color4(Color.DarkKhaki);
            public static readonly Color4 DarkMagenta = new Color4(Color.DarkMagenta);
            public static readonly Color4 DarkOliveGreen = new Color4(Color.DarkOliveGreen);
            public static readonly Color4 DarkOrange = new Color4(Color.DarkOrange);
            public static readonly Color4 DarkOrchid = new Color4(Color.DarkOrchid);
            public static readonly Color4 DarkRed = new Color4(Color.DarkRed);
            public static readonly Color4 DarkSalmon = new Color4(Color.DarkSalmon);
            public static readonly Color4 DarkSeaGreen = new Color4(Color.DarkSeaGreen);
            public static readonly Color4 DarkSlateBlue = new Color4(Color.DarkSlateBlue);
            public static readonly Color4 DarkSlateGray = new Color4(Color.DarkSlateGray);
            public static readonly Color4 DarkTurquoise = new Color4(Color.DarkTurquoise);
            public static readonly Color4 DarkViolet = new Color4(Color.DarkViolet);
            public static readonly Color4 DeepPink = new Color4(Color.DeepPink);
            public static readonly Color4 DeepSkyBlue = new Color4(Color.DeepSkyBlue);
            public static readonly Color4 DimGray = new Color4(Color.DimGray);
            public static readonly Color4 DodgerBlue = new Color4(Color.DodgerBlue);
            public static readonly Color4 Firebrick = new Color4(Color.Firebrick);
            public static readonly Color4 FloralWhite = new Color4(Color.FloralWhite);
            public static readonly Color4 ForestGreen = new Color4(Color.ForestGreen);
            public static readonly Color4 Fuchsia = new Color4(Color.Fuchsia);
            public static readonly Color4 Gainsboro = new Color4(Color.Gainsboro);
            public static readonly Color4 GhostWhite = new Color4(Color.GhostWhite);
            public static readonly Color4 Gold = new Color4(Color.Gold);
            public static readonly Color4 Goldenrod = new Color4(Color.Goldenrod);
            public static readonly Color4 Gray = new Color4(Color.Gray);
            public static readonly Color4 Green = new Color4(Color.Green);
            public static readonly Color4 GreenYellow = new Color4(Color.GreenYellow);
            public static readonly Color4 Honeydew = new Color4(Color.Honeydew);
            public static readonly Color4 HotPink = new Color4(Color.HotPink);
            public static readonly Color4 IndianRed = new Color4(Color.IndianRed);
            public static readonly Color4 Indigo = new Color4(Color.Indigo);
            public static readonly Color4 Ivory = new Color4(Color.Ivory);
            public static readonly Color4 Khaki = new Color4(Color.Khaki);
            public static readonly Color4 Lavender = new Color4(Color.Lavender);
            public static readonly Color4 LavenderBlush = new Color4(Color.LavenderBlush);
            public static readonly Color4 LawnGreen = new Color4(Color.LawnGreen);
            public static readonly Color4 LemonChiffon = new Color4(Color.LemonChiffon);
            public static readonly Color4 LightBlue = new Color4(Color.LightBlue);
            public static readonly Color4 LightCoral = new Color4(Color.LightCoral);
            public static readonly Color4 LightCyan = new Color4(Color.LightCyan);
            public static readonly Color4 LightGoldenrodYellow = new Color4(Color.LightGoldenrodYellow);
            public static readonly Color4 LightGray = new Color4(Color.LightGray);
            public static readonly Color4 LightGreen = new Color4(Color.LightGreen);
            public static readonly Color4 LightPink = new Color4(Color.LightPink);
            public static readonly Color4 LightSalmon = new Color4(Color.LightSalmon);
            public static readonly Color4 LightSeaGreen = new Color4(Color.LightSeaGreen);
            public static readonly Color4 LightSkyBlue = new Color4(Color.LightSkyBlue);
            public static readonly Color4 LightSlateGray = new Color4(Color.LightSlateGray);
            public static readonly Color4 LightSteelBlue = new Color4(Color.LightSteelBlue);
            public static readonly Color4 LightYellow = new Color4(Color.LightYellow);
            public static readonly Color4 Lime = new Color4(Color.Lime);
            public static readonly Color4 LimeGreen = new Color4(Color.LimeGreen);
            public static readonly Color4 Linen = new Color4(Color.Linen);
            public static readonly Color4 Magenta = new Color4(Color.Magenta);
            public static readonly Color4 Maroon = new Color4(Color.Maroon);
            public static readonly Color4 MediumAquamarine = new Color4(Color.MediumAquamarine);
            public static readonly Color4 MediumBlue = new Color4(Color.MediumBlue);
            public static readonly Color4 MediumOrchid = new Color4(Color.MediumOrchid);
            public static readonly Color4 MediumPurple = new Color4(Color.MediumPurple);
            public static readonly Color4 MediumSeaGreen = new Color4(Color.MediumSeaGreen);
            public static readonly Color4 MediumSlateBlue = new Color4(Color.MediumSlateBlue);
            public static readonly Color4 MediumSpringGreen = new Color4(Color.MediumSpringGreen);
            public static readonly Color4 MediumTurquoise = new Color4(Color.MediumTurquoise);
            public static readonly Color4 MediumVioletRed = new Color4(Color.MediumVioletRed);
            public static readonly Color4 MidnightBlue = new Color4(Color.MidnightBlue);
            public static readonly Color4 MintCream = new Color4(Color.MintCream);
            public static readonly Color4 MistyRose = new Color4(Color.MistyRose);
            public static readonly Color4 Moccasin = new Color4(Color.Moccasin);
            public static readonly Color4 NavajoWhite = new Color4(Color.NavajoWhite);
            public static readonly Color4 Navy = new Color4(Color.Navy);
            public static readonly Color4 OldLace = new Color4(Color.OldLace);
            public static readonly Color4 Olive = new Color4(Color.Olive);
            public static readonly Color4 OliveDrab = new Color4(Color.OliveDrab);
            public static readonly Color4 Orange = new Color4(Color.Orange);
            public static readonly Color4 OrangeRed = new Color4(Color.OrangeRed);
            public static readonly Color4 Orchid = new Color4(Color.Orchid);
            public static readonly Color4 PaleGoldenrod = new Color4(Color.PaleGoldenrod);
            public static readonly Color4 PaleGreen = new Color4(Color.PaleGreen);
            public static readonly Color4 PaleTurquoise = new Color4(Color.PaleTurquoise);
            public static readonly Color4 PaleVioletRed = new Color4(Color.PaleVioletRed);
            public static readonly Color4 PapayaWhip = new Color4(Color.PapayaWhip);
            public static readonly Color4 PeachPuff = new Color4(Color.PeachPuff);
            public static readonly Color4 Peru = new Color4(Color.Peru);
            public static readonly Color4 Pink = new Color4(Color.Pink);
            public static readonly Color4 Plum = new Color4(Color.Plum);
            public static readonly Color4 PowderBlue = new Color4(Color.PowderBlue);
            public static readonly Color4 Purple = new Color4(Color.Purple);
            public static readonly Color4 Red = new Color4(Color.Red);
            public static readonly Color4 RosyBrown = new Color4(Color.RosyBrown);
            public static readonly Color4 RoyalBlue = new Color4(Color.RoyalBlue);
            public static readonly Color4 SaddleBrown = new Color4(Color.SaddleBrown);
            public static readonly Color4 Salmon = new Color4(Color.Salmon);
            public static readonly Color4 SandyBrown = new Color4(Color.SandyBrown);
            public static readonly Color4 SeaGreen = new Color4(Color.SeaGreen);
            public static readonly Color4 SeaShell = new Color4(Color.SeaShell);
            public static readonly Color4 Sienna = new Color4(Color.Sienna);
            public static readonly Color4 Silver = new Color4(Color.Silver);
            public static readonly Color4 SkyBlue = new Color4(Color.SkyBlue);
            public static readonly Color4 SlateBlue = new Color4(Color.SlateBlue);
            public static readonly Color4 SlateGray = new Color4(Color.SlateGray);
            public static readonly Color4 Snow = new Color4(Color.Snow);
            public static readonly Color4 SpringGreen = new Color4(Color.SpringGreen);
            public static readonly Color4 SteelBlue = new Color4(Color.SteelBlue);
            public static readonly Color4 Tan = new Color4(Color.Tan);
            public static readonly Color4 Teal = new Color4(Color.Teal);
            public static readonly Color4 Thistle = new Color4(Color.Thistle);
            public static readonly Color4 Tomato = new Color4(Color.Tomato);
            public static readonly Color4 Turquoise = new Color4(Color.Turquoise);
            public static readonly Color4 Violet = new Color4(Color.Violet);
            public static readonly Color4 Wheat = new Color4(Color.Wheat);
            public static readonly Color4 White = new Color4(Color.White);
            public static readonly Color4 WhiteSmoke = new Color4(Color.WhiteSmoke);
            public static readonly Color4 Yellow = new Color4(Color.Yellow);
            public static readonly Color4 YellowGreen = new Color4(Color.YellowGreen);
        }
        #endregion
    }
}
