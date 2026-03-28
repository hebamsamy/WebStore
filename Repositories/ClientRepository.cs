using EcommerceDB.Context;
using EcommerceDB.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class ClientRepository:MainRepository<Client>
    {
        public ClientRepository(EcommerceDBContext context):base(context)
        {
            
        }
    }
}
