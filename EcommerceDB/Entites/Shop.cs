using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceDB.Entites
{
    public class Shop
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Image { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public int ProviderID { get; set; }
        public virtual Provider Provider { get; set; }

    }
}
