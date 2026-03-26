using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceDB.Entites
{
    public class Client
    {
        public int Id { get; set; }


        public string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
