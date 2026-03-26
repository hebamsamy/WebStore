using EcommerceDB.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViewModel;

namespace EmptyMVC
{
    public class TopProductsViewComponent : ViewComponent
    {

         EcommerceDBContext dBContext ;
        public TopProductsViewComponent(EcommerceDBContext dBContext)
        {
            this.dBContext = dBContext ;
        }
        public IViewComponentResult Invoke(int count = 4, string type = null)
        {

            if (!string.IsNullOrEmpty(type) && type.ToLower() == "sales")
            {

                var items = dBContext.Products
                    .OrderByDescending(p => p.Items.Count)
                    .Take(count).AsQueryable()
                    .ToProductDetailsVM();

                return View(items);
            }

            var list = dBContext.Products
                    .OrderByDescending(p => p.Stock)
                    .Take(count).AsQueryable()
                    .ToProductDetailsVM();

            return View(list);

        }

    }
}
