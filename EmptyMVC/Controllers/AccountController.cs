using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories;
using ViewModel;

namespace EmptyMVC.Controllers
{
    public class AccountController : Controller
    {
        UserRepository userRepository;
        RoleRepesitoty roleRepesitoty;
        public AccountController(UserRepository _userRepository,RoleRepesitoty _roleRepesitoty)
        {
            userRepository = _userRepository;
            roleRepesitoty = _roleRepesitoty;
        }
        /// <summary>
        /// Action /method
        /// 
        /// must public
        /// must be NON static
        /// must return
        /// One Condtion overload
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            ViewData["roles"] = roleRepesitoty
                .GelList().Where(i => i.NormalizedName != "ADMIN")
                .Select(i => new SelectListItem(i.Name, i.Name)).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel viewModel)
        {
            if (ModelState.IsValid) {
                var res = await userRepository.Register(viewModel);
                if (res.Succeeded)
                {
                    return RedirectToAction("login");
                }
                else
                {
                    foreach (var item in res.Errors)
                    {
                        ModelState.AddModelError("all", item.Description);
                    }
                    ViewData["roles"] = roleRepesitoty
                   .GelList().Where(i => i.NormalizedName != "ADMIN")
                   .Select(i => new SelectListItem(i.Name, i.Name)).ToList();
                    return View(viewModel);
                }
            }
            ViewData["roles"] = roleRepesitoty
               .GelList().Where(i => i.NormalizedName != "ADMIN")
               .Select(i => new SelectListItem(i.Name, i.Name)).ToList();
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Login(string ReturnUrl = "/")
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel viewModel, string ReturnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                var res= await userRepository.Login(viewModel);
                if (res.Succeeded)
                {
                    return RedirectToAction("index", "Product");
                }
                else
                {
                    if (res.IsLockedOut) ModelState.AddModelError("all", "Many Incorrect Login Attmed try again later!!");
                    else if (res.IsNotAllowed) ModelState.AddModelError("all", "Incorrect Email or Password!!");
                    return View(viewModel);
                }
            }


            return View(viewModel);
        }



        public ContentResult content()
        {
            return new ContentResult { Content = "Say HIiiiiiii" };
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await userRepository.Logout();
            return RedirectToAction("login");
        }


    }
}
