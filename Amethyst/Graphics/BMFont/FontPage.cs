using System;
using System.Xml;
using System.Xml.Serialization;

namespace Amethyst.Graphics.BMFont
{
    #pragma warning disable 1591
    
    [Serializable]
    public class FontPage
    {
        [XmlAttribute("id")]
        public Int32 ID { get; set; }

        [XmlAttribute("file")]
        public String File { get; set; }
    }
}
