using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cw2.data.Models
{
    public class Students
    {

        [XmlElement(elementName: "student")]
        public List<Student> student { get; set; }
    }
}
