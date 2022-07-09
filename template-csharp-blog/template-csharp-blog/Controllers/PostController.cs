using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using template_csharp_blog.Models;

namespace template_csharp_blog.Controllers
{
    public class PostController : Controller
    {
        public BlogContext db;

        public PostController(BlogContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
   
            return View(new Post());
        }

        [HttpPost]
        public IActionResult Create(Post model)
        {
           
            List<Post> posts = db.Posts.ToList();
            for (int i = 0; i < posts.Count; i++)
            {
                if (posts[i].Title == model.Title)
                {
                    ViewBag.Warning = "That post already exists!";
                    return View(model);
                }
            }
            db.Posts.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            return View(db.Posts.ToList().Where(t => t.Id == id).FirstOrDefault());
        }
        public IActionResult Update(int id)
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");

            Post post = db.Posts.Find(id); 
        if (post == null)
        {
            return View("Error");
        }
        return View(post);
        }

        [HttpPost]
        public IActionResult Update(Post model)
        {
            db.Posts.Update(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Post post = db.Posts.Find(id);
            return View(post);
        }

        [HttpPost]
        public IActionResult Delete(Post model)
        {
            db.Posts.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

