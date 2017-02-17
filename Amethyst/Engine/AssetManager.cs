using Amethyst.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amethyst.Engine
{
    /// <summary>
    /// Asset management class
    /// </summary>
    public static class AssetManager
    {
        /// <summary>
        /// Collection of Built-in fonts
        /// </summary>
        public static class BuiltinFonts
        {
            /// <summary>
            /// Font "System", size 24
            /// </summary>
            public static Font SYSTEM_24 { get; set; } = Font.FromXMLSrc(Fonts.SYSTEM_24, new Texture(Fonts.SYSTEM_24_TEX, System.Drawing.Color.Magenta));
            /// <summary>
            /// Font "Arial Black", size 48
            /// </summary>
            public static Font ARIAL_BLACK_48 { get; set; } = Font.FromXMLSrc(Fonts.ARIAL_BLACK_48, new Texture(Fonts.ARIAL_BLACK_48_TEX, System.Drawing.Color.Magenta));
        }
        
        static AssetManager() { }

        #region FONTS
        public class FontCollection
        {
            private Dictionary<string, Font> m_Fonts = new Dictionary<string, Font>();
            public Font this[string name]
            {
                get
                {
                    return m_Fonts.ContainsKey(name) ? m_Fonts[name] : null;
                }
                set
                {
                    m_Fonts[name] = value;
                }
            }
        }
        public static FontCollection CustomFonts = new FontCollection();
        #endregion

        #region TEXTURES
        public class TextureCollection
        {
            private Dictionary<string, Texture> m_Textures = new Dictionary<string, Texture>();
            public Texture this[string name]
            {
                get
                {
                    return m_Textures.ContainsKey(name) ? m_Textures[name] : null;
                }
                set
                {
                    m_Textures[name] = value;
                }
            }
        }
        public static TextureCollection CustomTextures = new TextureCollection();
        #endregion
    }
}
