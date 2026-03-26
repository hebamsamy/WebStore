using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceDB.Entites
{
    public class User :IdentityUser
    {

        public string? ProfilePictue { get; set; }
        public string FullName {  get; set; }


        public virtual Provider? Provider { get; set; }
        public virtual Client? Client { get; set; }

    }
}
