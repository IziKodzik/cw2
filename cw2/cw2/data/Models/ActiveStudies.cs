using cw2.data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cw2.data
{
    public class ActiveStudies
    {
        [XmlElement(elementName: "studies")]
        public List<AC> ACl { get; set; }
    }
}
