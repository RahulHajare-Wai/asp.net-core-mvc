using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController1 : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController1(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //it will retrive all of the categories from database and convert it into the list.
            IEnumerable<Category> objCategoryList = _db.Categories; 
            return View(objCategoryList);
        }

        //Get
        public IActionResult Create()
        {
            //it will retrive all of the categories from database and convert it into the list.
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]//help and prevent the cross site forgery attacks.
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot be exactly match with the Name. ");
            }
            
            if(ModelState.IsValid)
            {
            _db.Categories.Add(obj);
            _db.SaveChanges();
             TempData["success"] = "Category created Successfully";
            return RedirectToAction("Index");
            }
            return View();
        }

        //Get
        public IActionResult Edit(int ? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            // var CategoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            // var CategoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]//help and prevent the cross site forgery attacks.
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot be exactly match with the Name. ");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                TempData["success"] = "Category Updated Successfully";

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            // var CategoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            // var CategoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //Post
        [HttpPost,ActionName("Delete")]// for using ActionName("Delete") you can use Delete instead of DeletePost().
        [ValidateAntiForgeryToken]//help and prevent the cross site forgery attacks.
        public IActionResult DeletePost(int?id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");

            return View();
        }
    }
}
