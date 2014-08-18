using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xsd2sql.entity
{
    public class OrderTbL
    {
        public string OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderAmt { get; set; }
        public string StaffId { get; set; }
    }
}
