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
        public string[] FileNames { get; set; }
		
		public int getFilenamesCount(){
			return (FileNames == null)? 0 : FileNames.Length;
		}
    }
}
