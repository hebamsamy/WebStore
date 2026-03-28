using EcommerceDB.Context;
using EcommerceDB.Entites;
using EmptyMVC.MiddleWires;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System.Text;

namespace EmptyMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder();


            #region DI/IOC Containter


            builder.Services.AddDbContext<EcommerceDBContext>(i =>
            i.UseLazyLoadingProxies()
            .UseSqlServer(builder.Configuration.GetConnectionString("localDB")));

            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<EcommerceDBContext>();

            builder.Services.AddScoped(typeof(ProductRepository));
            builder.Services.AddScoped(typeof(CategoryRepository));
            builder.Services.AddScoped(typeof(UserRepository));
            builder.Services.AddScoped(typeof(RoleRepesitoty));
            builder.Services.AddScoped(typeof(ProviderRepository));
            builder.Services.AddScoped(typeof(ClientRepository));

            //config 
            //services
            builder.Services.AddControllersWithViews();

            //reflaction
            //search all .cs 
            //Accountconttroller.cs
            //Homeconttroller.cs() =>index
            //table 
            #endregion


            var app = builder.Build();



            #region Custom Middleware
            //Use

            //Next

            //Map

            //Run


            //app.UseMiddleware<ProductListMiddelware>();
            //app.UseMiddleware<ProductDetailsMiddelware>();

            //app.Run(async (context) =>
            //{
            //    if (context.Request.Path == "/")
            //    {
            //        await context.Response.WriteAsync(" <h1>Welcome In Our App </h1>");
            //    }
            //}); 

            #endregion

            app.MapStaticAssets();

            app.UseRouting();

            app.UseAuthentication(); //check account 
            app.UseAuthorization(); //check Premission

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Product}/{action=Index}/{id?}");


            app.Run();

        }
    }
}
