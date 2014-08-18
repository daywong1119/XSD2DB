using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xsd2sql.DataSetObject;
using System.Xml.Serialization;

namespace xsd2sql
{
    [Serializable]
    public class DbTbl
    {
        [XmlAttribute("tblName")]
        public string TableName { get; set; }

        [XmlElement("htmlFile")]
        public HtmlFile HtmlFile { get; set; }

        [XmlElement("byhtmlTBLId", IsNullable = true)]
        public ByHtmlTBLId[] HtmlTableIdList { get; set; }

        [XmlElement("byMatching", IsNullable = true)]
        public ByMatching[] MatchingList { get; set; }

        [XmlIgnore]
        public HtmlFile HtmlFilesCount
        {
            get
            {
                return (HtmlFile == null) ? null : HtmlFile;
            }
        }
    }
}
