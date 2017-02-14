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
    public sealed class AssetManager
    {
        /// <summary>
        /// Collection of Built-in fonts
        /// </summary>
        public static class BuiltinFonts
        {
            /// <summary>
            /// Font "System", size 24
            /// </summary>
            public const string SYSTEM_24 = "SYSTEM_24";
            /// <summary>
            /// Font "Arial Black", size 48
            /// </summary>
            public const string ARIAL_BLACK_48 = "ARIAL_BLACK_48";
        }
        
        /// <summary>
        /// Get the singleton instance of AssetManager
        /// </summary>
        public static AssetManager Instance { get; } = new AssetManager();
        static AssetManager() { }
        private AssetManager()
        {
            // Load Built-in Fonts
            AddFont(BuiltinFonts.SYSTEM_24, Font.FromXMLSrc(Fonts.SYSTEM_24, new Texture(Fonts.SYSTEM_24_TEX, System.Drawing.Color.Magenta)));
            AddFont(BuiltinFonts.ARIAL_BLACK_48, Font.FromXMLSrc(Fonts.ARIAL_BLACK_48, new Texture(Fonts.ARIAL_BLACK_48_TEX, System.Drawing.Color.Magenta)));
            // Load Built-in Textures
        }

        #region FONTS
        Dictionary<string, Font> m_Fonts = new Dictionary<string, Font>();
        /// <summary>
        /// Add a Font to the AssetManager
        /// </summary>
        /// <param name="name">The name of the font, must be unique</param>
        /// <param name="font">The font to attach to the name</param>
        /// <returns>True if the font was added, false otherwise (name duplicate)</returns>
        public bool AddFont(string name, Font font)
        {
            if (m_Fonts.ContainsKey(name))
            {
                return false;
            }

            m_Fonts.Add(name, font);

            return true;
        }
        /// <summary>
        /// Get the font linked to a given name
        /// </summary>
        /// <param name="name">The name of the Font</param>
        /// <returns>The Font linked to the name, null if the name doesn't exist</returns>
        public Font GetFont(string name)
        {
            if (!m_Fonts.ContainsKey(name))
            {
                return null;
            }

            return m_Fonts[name];
        }
        #endregion

        #region TEXTURES
        Dictionary<string, Texture> m_Textures = new Dictionary<string, Texture>();
        /// <summary>
        /// Add a Texture to the AssetManager
        /// </summary>
        /// <param name="name">The name of the texture, must be unique</param>
        /// <param name="texture">The texture to attach to the name</param>
        /// <returns>True if the texture was added, false otherwise (name duplicate)</returns>
        public bool AddTexture(string name, Texture texture)
        {
            if (m_Textures.ContainsKey(name))
            {
                return false;
            }

            m_Textures.Add(name, texture);

            return true;
        }
        /// <summary>
        /// Get the Texture linked to a given name
        /// </summary>
        /// <param name="name">The name of the Texture</param>
        /// <returns>The Texture linked to the name, null if the name doesn't exist</returns>
        public Texture GetTexture(string name)
        {
            if (!m_Textures.ContainsKey(name))
            {
                return null;
            }

            return m_Textures[name];
        }
        #endregion
    }
}
