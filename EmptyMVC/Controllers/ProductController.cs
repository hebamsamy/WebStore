using EcommerceDB.Context;
using EcommerceDB.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repositories;
using ViewModel;

namespace EmptyMVC.Controllers
{
    //[Authorize]
    public class ProductController : Controller
    {
        ProductRepository repository;
        CategoryRepository categoryRepository;
        ProviderRepository providerRepository;
        public ProductController( 
            ProductRepository _repository, 
            CategoryRepository _categoryRepository,
            ProviderRepository _providerRepository)
        {
            repository = _repository;
            categoryRepository = _categoryRepository;
            providerRepository = _providerRepository;   
           
        }
        //product/index?
        [HttpGet]
        public IActionResult Index(int categoryid=0, int Providerid=0, string searchtext=null,
            int pageSize=8,int pagenumber=1, decimal price=0
            , string orderby = "ID", bool isAcd = false)
        {
            var products=  repository.Get(categoryid,Providerid, searchtext, pageSize,pagenumber, price);
            //repository.Get(categoryid:categoryid);

            #region model binder
            //pass to view
            //good passing extra Data
            ViewBag.PageNumber = pagenumber;
            //ViewData["date"] = DateTime.Now.ToShortDateString();
            ViewData["CategoryList"] = categoryRepository.GelList().ToList();
            //bad magic string
            //explict casting (return Object)


            //ViewBag.clr ="blue";
            // return dynamic
            // runtime exeptions

            //ViewBag.date = "texxxxxt";//add "date"  => overwrite


            TempData["date"] = DateTime.Now.ToShortDateString(); 
            #endregion

            return View("List",products);
        }
        //product/details?id=1
        public IActionResult Details(int id)
        {
            var product = repository.GetOne(p => p.ID == id);
            //if (TempData.ContainsKey("date"))
            //{
            //    var date = TempData["date"];
            //}
            return View(product);
        }
        public IActionResult Search()
        {
            return View();
        }
        [Authorize (Roles ="Provider")]
        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> categories = categoryRepository.GelList()
                .Select(c=>new SelectListItem(c.Name,c.ID.ToString())).ToList();
            ViewData["categories"] = categories;
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Provider")]
        public IActionResult Add(AddProductViewModel viewModel)
        {
            var UserData = User.FindFirstValue(ClaimTypes.NameIdentifier);
            viewModel.ProviderID = providerRepository.GetOne(p => p.UserId == UserData).ID;

            if (ModelState.IsValid)
            {
                //Save Image
                foreach(var file in viewModel.Attachment)
                {
                    string uniquFileName = Guid.NewGuid().ToString() + file.FileName;
                    string UploadPath = Path.Combine(
                        Directory.GetCurrentDirectory(), 
                        "wwwroot", "images", "ProductAttachments",
                        uniquFileName);

                    var fileStream = new FileStream(UploadPath, FileMode.Create);
                    
                    file.CopyTo(fileStream);

                    fileStream.Close();

                    viewModel.ImagePaths.Add(Path.Combine("images", "ProductAttachments", uniquFileName));
                }
                
                bool status=  repository.Add(viewModel);
                if (status)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    ModelState.AddModelError("all", "Sorry Something went wrong try agin later!!!");

                    List<SelectListItem> categories = categoryRepository.GelList()
                .Select(c => new SelectListItem(c.Name, c.ID.ToString())).ToList();
                    ViewData["categories"] = categories;

                    return View(viewModel);
                }

            }
            else
            {
                List<SelectListItem> categories = categoryRepository.GelList()
                    .Select(c => new SelectListItem(c.Name, c.ID.ToString())).ToList();
                ViewData["categories"] = categories;
                return View(viewModel);

            }
        }

        [HttpGet]
        [Authorize(Roles ="Provider")]
        public IActionResult GetMyProduct()
        {
            ViewData["CategoryList"] = categoryRepository.GelList().ToList();

            var UserData = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int CurrentloggedinProvider = providerRepository.GetOne(p => p.UserId == UserData).ID;

            var data = repository.GelList().Where(p => p.ProviderID == CurrentloggedinProvider)
                .ToProductDetailsVM();

            
            return View("list", data);
        }
    }
}
