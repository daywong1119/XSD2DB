using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace xsd2sql.DataSetObject
{
    [Serializable]
    public class ById
    {
        [XmlAttribute("fieldName")]
        public string FieldName { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
}
