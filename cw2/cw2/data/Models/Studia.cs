using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cw2.data.Models
{
    public class Studia
    {
        [XmlElement(elementName: "name")]
        public String nazwa { set; get; }
        [XmlElement(elementName: "mode")]
        public String tryb { set; get; }
    }
}
