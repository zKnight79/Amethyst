using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

using Amethyst.Graphics.BMFont;
using Amethyst.Math;

namespace Amethyst.Graphics
{
    /// <summary>
    /// Class representing a font, for 2D text rendering
    /// </summary>
    public class Font
    {
        /// <summary>
        /// Logical descrition of the Font, using BMFont
        /// </summary>
        public FontDesc FontDesc { get; private set; }
        /// <summary>
        /// The texture containing the characters
        /// </summary>
        public Texture Texture { get; private set; }

        private Font() { }

        /// <summary>
        /// Creates a Font from a BMFont 'fnt' file<br />
        /// Automatically loads the texture<br />
        /// FNT file must be in XML format
        /// </summary>
        /// <param name="filename">The filename of the font descrition file<br />
        /// Texture file must be in the same directory</param>
        /// <returns>The newly created Font</returns>
        public static Font FromXMLFile(string filename)
        {
            Font font = new Font();

            font.FontDesc = FontDesc.FromXMLFile(filename);
            font.Texture = new Texture(Path.Combine(Path.GetDirectoryName(Path.GetFullPath(filename)), font.FontDesc.Pages[0].File), System.Drawing.Color.Magenta);
            
            return font;
        }
        /// <summary>
        /// Creates a Font from a BMFont xml source<br />
        /// Does not load the texture from the BMFont descrition
        /// </summary>
        /// <param name="xmlSrc">The BMFont xml source</param>
        /// <param name="texture">The texture containing the characters</param>
        /// <returns>The newly created Font</returns>
        public static Font FromXMLSrc(string xmlSrc, Texture texture)
        {
            Font font = new Font();

            font.FontDesc = FontDesc.FromXMLSrc(xmlSrc);
            font.Texture = texture;

            return font;
        }

        /// <summary>
        /// Get an array of the logical FontChars used to render the given text
        /// </summary>
        /// <param name="text">The text we want to know the used chars</param>
        /// <returns>An array of FontChar</returns>
        public FontChar[] GetChars(string text)
        {
            FontChar[] array = null;
            List<FontChar> list = new List<FontChar>();

            foreach (char c in text)
            {
                if (c == '\n')
                {
                    list.Add(null);
                }
                else
                {
                    foreach (FontChar fc in FontDesc.Chars)
                    {
                        if (fc.ID == c)
                        {
                            list.Add(fc);
                            break;
                        }
                    }
                }
            }

            if (list.Count > 0)
            {
                array = list.ToArray();
            }
            list.Clear();

            return array;
        }
        /// <summary>
        /// Get the length in pixels used for rendering the given text on a single line
        /// </summary>
        /// <param name="text">The text we want to know the length</param>
        /// <returns>The length in pixels used for rendering the given text on a single line</returns>
        public int GetTextLength(string text)
        {
            int len = 0;

            FontChar[] chars = GetChars(text);
            if (chars != null)
            {
                foreach (FontChar fc in chars)
                {
                    len += fc.XAdvance + FontDesc.Info.OutLine;
                }
            }
            
            return len;
        }
        /// <summary>
        /// Generate the word-wrapped version of a given text, based on a given maximum width in pixels
        /// </summary>
        /// <param name="text">The text to word-wrap</param>
        /// <param name="width">The given maximum width in pixels</param>
        /// <returns>The word-wrapped text</returns>
        public string GenerateWordWrap(string text, int width)
        {
            text = text.Replace("\r\n", "\n");

            if (width < FontDesc.Info.Size)
            {
                return text;
            }

            StringBuilder wwText = new StringBuilder();

            string[] lines = text.Split('\n');
            if (lines != null)
            {
                for (int i = 0; i < lines.Length;++i )
                {
                    string line = lines[i].Trim();
                    if (wwText.Length != 0)
                    {
                        wwText.Append('\n');
                    }
                    while (line.Length > 0)
                    {
                        if (GetTextLength(line) <= width)
                        {
                            wwText.Append(line);
                            break;
                        }
                        string tmp = line;
                        do
                        {
                            int pos = tmp.LastIndexOf(' ');
                            tmp = tmp.Substring(0, pos);
                        } while ((tmp.IndexOf(' ') >= 0) && (GetTextLength(tmp) > width));
                        wwText.Append(tmp.Trim());
                        wwText.Append('\n');
                        line = line.Substring(tmp.Length).Trim();
                    }
                }
            }
            
            return wwText.ToString();
        }
    }
}
