using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cw2.data.Models
{
    public class AC
    {
        [XmlAttribute(attributeName: "name")]
        public String name { get; set; }

        [XmlAttribute(attributeName: "numberOfStudents")]
        public int number { get; set; }

    }
}
