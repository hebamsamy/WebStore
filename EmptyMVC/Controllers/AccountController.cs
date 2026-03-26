using Microsoft.AspNetCore.Mvc;
using Repositories;
using ViewModel;

namespace EmptyMVC.Controllers
{
    public class AccountController : Controller
    {
        UserRepository userRepository;
        public AccountController(UserRepository _userRepository)
        {
            userRepository = _userRepository;
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
                    return View(viewModel);
                }
            }

            
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel viewModel)
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
        //public IActionResult Login(Form Data)
        //{
        //    return View();
        //}


    }
}
