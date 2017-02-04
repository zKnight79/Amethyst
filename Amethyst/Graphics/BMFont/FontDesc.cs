using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Amethyst.Graphics.BMFont
{
    #pragma warning disable 1591

    [Serializable]
    [XmlRoot("font")]
    public class FontDesc
    {
        [XmlElement("info")]
        public FontInfo Info { get; set; }

        [XmlElement("common")]
        public FontCommon Common { get; set; }

        [XmlArray("pages")]
        [XmlArrayItem("page")]
        public List<FontPage> Pages { get; set; }

        [XmlArray("chars")]
        [XmlArrayItem("char")]
        public List<FontChar> Chars { get; set; }

        [XmlArray("kernings")]
        [XmlArrayItem("kerning")]
        public List<FontKerning> Kernings { get; set; }

        public static FontDesc FromXMLFile(string filename)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(FontDesc));
            TextReader textReader = new StreamReader(filename);
            FontDesc desc = (FontDesc)deserializer.Deserialize(textReader);
            textReader.Close();
            return desc;
        }

        public static FontDesc FromXMLSrc(string xmlSrc)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(FontDesc));
            StringReader stringReader = new StringReader(xmlSrc);
            XmlReader xml = XmlReader.Create(stringReader);
            FontDesc desc = (FontDesc)deserializer.Deserialize(xml);
            xml.Close();
            stringReader.Close();
            stringReader.Dispose();
            return desc;
        }
    }
}
