using Microsoft.AspNetCore.Mvc;
using Bulky.Data;
using Bulky.Models;
namespace Bulky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            //System.Diagnostics.Debug.WriteLine("Category List Count: " + objCategoryList.Count);
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //System.Diagnostics.Debug.WriteLine("Debug mode me yeh chalega");
            try
            {
                if (obj.Name == obj.DisplayOrder.ToString())
                {
                    //ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
                    //return View(obj);
                    throw new Exception("The DisplayOrder cannot exactly match the Name.");
                }
                if (ModelState.IsValid)
                {
                    _db.Categories.Add(obj);
                    _db.SaveChanges();
                    TempData["success"] = "Category created successfully";
                }
            }
            catch (Exception ex)
            {
                //System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                ModelState.AddModelError("", ex.Message);
                return View(obj);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
