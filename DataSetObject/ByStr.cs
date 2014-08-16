using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace xsd2sql.DataSetObject
{
    [Serializable]
    public class ByStr
    {
        [XmlAttribute("fieldName")]
        public string FieldName { get; set; }
        [XmlElement("startStr")]
        public string StartStr { get; set; }
        [XmlElement("endStr")]
        public string EndStr { get; set; }
    }
}
