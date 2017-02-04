using System;
using System.Xml;
using System.Xml.Serialization;

namespace Amethyst.Graphics.BMFont
{
    #pragma warning disable 1591

    [Serializable]
    public class FontKerning
    {
        [XmlAttribute("first")]
        public Int32 First { get; set; }

        [XmlAttribute("second")]
        public Int32 Second { get; set; }

        [XmlAttribute("amount")]
        public Int32 Amount { get; set; }
    }
}
