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

        public string[] FieldNameList
        {
            get
            {
                if (ColMatchList == null || ColMatchList.Length == 0) return null;
                return ColMatchList.Select(x => x.FieldName).ToArray();

            }

        }


        public string[] HeaderNameList
        {
            get
            {
                if (ColMatchList == null || ColMatchList.Length == 0) return null;
                return ColMatchList.Select(x => x.Value).ToArray();

            }
        }
    }
}
