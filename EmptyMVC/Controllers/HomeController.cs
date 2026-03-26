using Microsoft.AspNetCore.Mvc;

namespace EmptyMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
            //return new JsonContent();
            //return Redirect("account/login");
        }
        public IActionResult error()
        {
            return View();
            //return new StringContent( " test Error");
        }
    }
}
