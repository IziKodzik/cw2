using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cw2.data.Models
{
    public class Student
    {
        //prop + tabx2
        [XmlElement(elementName:"fname")]
        public string Imie { get; set; }

        public string Nazwisko { get; set; }
        [XmlAttribute(attributeName:"email")]
        public string Email { get; set; }
    }
}
