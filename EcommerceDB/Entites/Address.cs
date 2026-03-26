using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EcommerceDB.Entites
{
    [ComplexType]
    public class Address
    {
        public int ZIPCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Notes { get; set; }
    }
}
