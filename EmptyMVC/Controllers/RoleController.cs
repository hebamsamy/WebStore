using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using ViewModel;

namespace EmptyMVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private RoleRepesitoty RoleRepesitoty;
        public RoleController(RoleRepesitoty roleRepesitoty) { 
            RoleRepesitoty = roleRepesitoty;
        }
        public IActionResult Index()
        {
            List<RoleViewModel> list = RoleRepesitoty
                .GelList()
                .Select(a => new RoleViewModel { Id = a.Id, Name = a.Name })
                .ToList();
            return View(list);
        }
        [HttpPost]
        public async Task<IActionResult> Add(string roleName) {

            if (roleName == null)
            {
                ViewBag.msg = "Must Provide Role Name";
            }
            else {
               var res= await RoleRepesitoty.Add(roleName);
                if (res.Succeeded)
                    ViewBag.msg = "Added Successfully";
                else
                    ViewBag.msg= res.Errors.ToString();
            }

            return RedirectToAction("index");
        }
    }
}
