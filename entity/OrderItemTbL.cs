using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xsd2sql.entity
{
    public class OrderItemTbL
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public int OrderQty { get; set; }
    }
}
