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

        [XmlElement(elementName: "lname")]
        public string Nazwisko { get; set; }

        [XmlElement(elementName: "birthdate")]
        public string DataUrodzenia { get; set; }

        [XmlAttribute(attributeName:"email")]
        public string Email { get; set; }

        [XmlElement(elementName: "mothersName")]
        public string Matka { get; set; }

        [XmlElement(elementName: "fathersName")]
        public string Ojciec { get; set; }

        [XmlElement(elementName: "studies")]
        public Studia stud { get; set; }
        
        public int index { get; set; }
    }
}
