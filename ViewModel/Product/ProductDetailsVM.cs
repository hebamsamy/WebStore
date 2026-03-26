using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class ProductDetailsVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }


        public  string ProviderName { get; set; }
        public string CategoryName { get; set; }

        public List<string> Attachments { get; set; }
    }
}
