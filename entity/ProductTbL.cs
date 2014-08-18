using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xsd2sql.entity
{
    public class ProductTbL
    {
        public string ProductId { get; set; }
        public string ProductDesc { get; set; }
        public int ProductQty { get; set; }
        public decimal ProductAmt { get; set; }
    }
}
