using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceDB.Entites
{
    public class ProductAttachment
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }



    }
}
