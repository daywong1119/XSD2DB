using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace xsd2sql.DataSetObject
{
    [Serializable]
    public class ByHtmlTBLId
    {
        [XmlAttribute("tblId")]
        public string TblId { get; set; }
        [XmlElement("colMatch")]
        public ColMatch[] ColMatchList { get; set; }
    }
}
