using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace xsd2sql
{
    [Serializable()]
    [XmlRoot("database")]
    public class DatabaseObject
    {
        [XmlAttribute("dbName")]
        public string DbName { get; set; }
        [XmlElement("dbTBL")]
        public DbTbl[] DbTables { get; set; }
    }
}
