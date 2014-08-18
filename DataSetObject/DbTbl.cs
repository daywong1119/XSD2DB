﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xsd2sql.DataSetObject;
using System.Xml.Serialization;

namespace xsd2sql
{
    [Serializable()]
    public class DbTbl
    {
        [XmlAttribute("tblName")]
        public string TableName { get; set; }
		
		[XmlElement("htmlFile")]
        public HtmlFile[] HtmlFile { get; set; }
		
		[XmlElement("byhtmlTBLId", IsNullable = true)]
        public ByHtmlTBLId[] HtmlTableIdS { get; set; }
		
		[XmlElement("byMatching", IsNullable = true)]
        public ByMatching[] MatchingS { get; set; }

		public int getHtmlFilesCount(){
			return (HtmlFile == null)? 0: HtmlFile.Length;
		}
		}
}