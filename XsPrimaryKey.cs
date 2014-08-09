using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xsd2sql
{
    public class XsPrimaryKey
    {
        public enum KeyType
        {
            IsPrimaryKey = 1,
            IsForeignKey = 2
        }

        public string KeyName { get; set; }
        public string Selector { get; set; }
        public string[] Fields { get; set; }
        public KeyType Keys { get; set; }
        public string ReferPrimaryKey { get; set; }
    }
}
