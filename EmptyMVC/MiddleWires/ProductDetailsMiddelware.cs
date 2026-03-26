using EcommerceDB.Context;
using System.Text;

namespace EmptyMVC.MiddleWires
{
    public class ProductDetailsMiddelware
    {
        public RequestDelegate Next { get; set; }
        EcommerceDBContext dBContext;
        public ProductDetailsMiddelware(RequestDelegate request, EcommerceDBContext dBContext) {
            Next = request;
            this.dBContext = dBContext;
        }

        public async Task InvokeAsync (HttpContext context)
        {
            //localhost:5004/productDetails?id=2
            if (context.Request.Path == "/productDetails")
            {
                int id  = int.Parse( context.Request.Query["id"]);
                var product = dBContext.Products.Find(id);
                
     
                await context.Response.WriteAsync($"<p> {product.Name} : {product.Price}$ </p>");
            }


            ///
            await Next(context);

        }
    }
}
