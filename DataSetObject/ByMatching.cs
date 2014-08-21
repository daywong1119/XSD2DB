using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace xsd2sql.DataSetObject
{
    [Serializable]
    public class ByMatching
    {
        [XmlElement("byId")]
        public ById[] ByIdList { get; set; }
        [XmlElement("byStr")]
        public ByStr[] ByStrList { get; set; }
    }
}
