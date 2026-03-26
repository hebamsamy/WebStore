using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceDB.Entites
{
    public class OrderItem
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        //Navigation Properties
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
