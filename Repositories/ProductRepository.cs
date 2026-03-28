using EcommerceDB.Context;
using EcommerceDB.Entites;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Repositories
{
    public class ProductRepository:MainRepository<Product>
    {
        public ProductRepository(EcommerceDBContext _context):base(_context)
        {
            
        }

        //where(prd=> prd .name && prd.price)
       public List<ProductDetailsVM> Get (int categoryid = 0, int Providerid = 0, string searchtext = null,
            int pageSize = 8, int pagenumber = 1, decimal price = 0,string orderby= "ID", bool isAcd =false)
        {
            var filter = PredicateBuilder.New<Product>();
            var oldfilter = filter;

            //where(prd=>prd.CategoryID == categoryid && prd => prd.ProviderID == Providerid && prd=>prd.Price<= price )

            if (categoryid > 0)
                filter = filter.And(prd=>prd.CategoryID == categoryid);
            if (Providerid > 0)
                filter = filter.And(prd => prd.ProviderID == Providerid);
            if(price>0)
                filter = filter.And(prd=>prd.Price<= price);
            if(!string.IsNullOrEmpty(searchtext))
                filter = filter.And(prd=> prd.Name.ToLower().Contains(searchtext.ToLower()) || prd.Description.ToLower().Contains(searchtext.ToLower()));

            if (oldfilter == filter)
                filter = null;

            return base.Get(filter, pagenumber, pageSize, orderby, isAcd)
                .Select(prd=>new ProductDetailsVM
            {
                ID = prd.ID,
                Name = prd.Name,
                Description = prd.Description,
                Price = price,
                Stock = prd.Stock,
                CategoryName = prd.Category.Name,
                ProviderName = prd.Provider.User.FullName,
                Attachments = prd.Attachments.Select(a=>a.Path).ToList()
            }).ToList();

        }
        public bool Add(AddProductViewModel viewModel)
        {
            Product product = new Product
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price,
                Stock = viewModel.Stock,
                CategoryID = viewModel.CategoryID,
                ISDeleted = false,
                ProviderID = viewModel.ProviderID,
                Attachments = viewModel.ImagePaths
                    .Select(img => new ProductAttachment { Path = img, }).ToList()
            };

            return base.Add(product);

        }
    }
}
