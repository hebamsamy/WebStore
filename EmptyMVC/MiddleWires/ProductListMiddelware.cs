using EcommerceDB.Context;
using System.Text;

namespace EmptyMVC.MiddleWires
{
    public class ProductListMiddelware
    {
        public RequestDelegate Next { get; set; }
                EcommerceDBContext dBContext ;
        public ProductListMiddelware(RequestDelegate request, EcommerceDBContext dBContext) {
            Next = request;
            this.dBContext = dBContext;
        }

        public async Task InvokeAsync (HttpContext context)
        {
            if (context.Request.Path == "/products")
            {
                var list = dBContext.Products.ToList();
                StringBuilder str = new StringBuilder();

                foreach (var product in list)
                {
                    str.Append($"<p> {product.Name} : {product.Price}$ </p>");
                }

                await context.Response.WriteAsync(str.ToString());
            }


            ///
           await Next(context);

        }
    }
}
