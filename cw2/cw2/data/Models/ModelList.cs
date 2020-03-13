using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cw2.data.Models
{
    //[XmlRoot("myOuterElement")]
    public class ModelList
    {
        [XmlAttribute(attributeName: "students")]
        public List<Student> List { get; set; }

    }
}
