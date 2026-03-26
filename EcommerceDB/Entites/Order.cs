using EcommerceDB.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceDB.Entites
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public virtual ICollection<OrderItem> Items { get; set; }

    }
}
