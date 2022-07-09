using Microsoft.AspNetCore.Mvc;
using template_csharp_blog.Models;

namespace template_csharp_blog.Controllers
{
    public class CategoryController : Controller
    {
        public BlogContext db;
        public CategoryController(BlogContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Categories);
        }

        public IActionResult Create()
        {
            

            return View(new Category());
        }

        [HttpPost]
        public IActionResult Create(Category model)
        {

            List<Category> Categories = db.Categories.ToList();
            for (int i = 0; i < Categories.Count; i++)
            {
                if (Categories[i].Name == model.Name)
                {
                   
                    return View(model);
                }
            }
            db.Categories.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            return View(db.Categories.ToList().Where(t => t.Id == id).FirstOrDefault());
        }
        public IActionResult Update(int id)
        {
           

            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return View("Error");
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(Category model)
        {
            db.Categories.Update(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Category category = db.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category model)
        {
            db.Categories.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

