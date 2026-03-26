using EcommerceDB.Context;
using EcommerceDB.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class CategoryRepository :MainRepository<Category>
    {
        public CategoryRepository(EcommerceDBContext _context):base(_context)
        {
            
        }



    }
}
