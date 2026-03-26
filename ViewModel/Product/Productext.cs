using EcommerceDB.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public static class Productext
    {
        public static List<ProductDetailsVM> ToProductDetailsVM(this IQueryable<Product> list) {
            return list.Select(p => new ProductDetailsVM {
                ID = p.ID,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                CategoryName = p.Category.Name,
                ProviderName = p.Provider.User.FullName,
                Attachments = p.Attachments.Select(a=>a.Path).ToList(),

            }).ToList();
        }
    }
}
