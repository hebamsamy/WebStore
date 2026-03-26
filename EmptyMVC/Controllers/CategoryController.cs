using EcommerceDB.Context;
using EcommerceDB.Entites;
using Microsoft.AspNetCore.Mvc;

namespace EmptyMVC.Controllers
{
    public class CategoryController : Controller
    {
        //https://localhost:59000/category/index/1?name=ali
        //https://localhost:59000/category/index?id=1&name=ali
        //https://localhost:59000/category/index?id=1&name=ali&colors=red&colors=blue
        //https://localhost:59000/category/index?id=1&name=ali&colors[1]=red&colors[0]=blue

        EcommerceDBContext dbcontext;
        public CategoryController(EcommerceDBContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }
        public IActionResult Index()
        {
            var list = dbcontext.Categories.ToList();

            return View(list);
        }
        [HttpGet]
        public IActionResult Add() {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            dbcontext.Categories.Add(category);
            dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) {

            var cat = dbcontext.Categories.Find(id);

            return View(cat);
        }
        [HttpPost]
        public IActionResult Edit(int id , Category newCategoty)
        {

            var oldCategry = dbcontext.Categories.Find(id);

            oldCategry.Name = newCategoty.Name;
            oldCategry.Description = newCategoty.Description;

            dbcontext.SaveChanges();
            return RedirectToAction("index");
        }


    }
}
