using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceDB.Entites
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public bool? ISDeleted { get; set; }



        ///Relation
        public int ProviderID { get; set; }
        public  virtual Provider Provider { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }
        public virtual ICollection<ProductAttachment> Attachments { get; set; }


    }
}
