using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceDB.Entites
{
    public class Provider
    {
        public int ID { get; set; }
        //public Class1.FullName FullName { get; set; }
        public string NationalID { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual Shop Shop { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
