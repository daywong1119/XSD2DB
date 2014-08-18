using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace xsd2sql.DataSetObject
{
    [Serializable]
    public class HtmlFile
    {
        [XmlElement("filename")]
        public string[] FileNameList { get; set; }
        [XmlText]
        public string Value { get; set; }

        [XmlIgnore]
        public int FileNameCount
        {
            get
            {
                return (FileNameList == null) ? 0 : FileNameList.Length;
            }
        }
    }
}
