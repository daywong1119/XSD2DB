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


        public string[] HeaderNameList
        {
            get
            {
                return GetAllHeaders();
            }
        }

        private string[] GetAllHeaders()
        {
            List<string[]> fieldList = new List<string[]>();
            List<string> headerName = new List<string>();
            if (ByIdList == null || ByIdList.Length == 0) return null;
            fieldList.Add(ByIdList.Select(x => x.FieldName).ToArray());

            if (ByStrList == null || ByStrList.Length == 0) return null;
            fieldList.Add(ByStrList.Select(x => x.FieldName).ToArray());

            //loop all value from field list
            foreach (string[] strArry in fieldList)
            {
                for (int i = 0; i < strArry.Length; i++)
                {
                    headerName.Add(strArry[i]);
                }
            }

            return headerName.ToArray();
        }
    }
}
    