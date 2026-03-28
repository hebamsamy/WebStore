using EcommerceDB.Context;
using EcommerceDB.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class ProviderRepository :MainRepository<Provider>
    {
        public ProviderRepository(EcommerceDBContext dBContext):base(dBContext)
        {
            
        }
    }
}
