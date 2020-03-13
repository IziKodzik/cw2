using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cw2.data.Models
{
    public class Uczelnia
    {

        [XmlAttribute(attributeName: "createdAt")]        
        public DateTime data { get; set; }

        [XmlAttribute(attributeName: "author")]
        public string autor { get; set; }

        [XmlElement(elementName: "studenci")]
        public List<Student> student { get; set; }
    }
}
