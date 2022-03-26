using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    [Area("Admin")]
    public class CategoryController1 : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController1(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //it will retrive all of the categories from database and convert it into the list.
            IEnumerable<Category> objCategoryList = _unitOfWork.Category.GetAll(); 
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
            _unitOfWork.Category.Add(obj);
            _unitOfWork.Save();
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
            //var categoryFromDb = _db.Categories.Find(id);
            var CategoryFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            // var CategoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (CategoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(CategoryFromDbFirst);
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
                _unitOfWork.Category.update(obj);
                TempData["success"] = "Category Updated Successfully";

                _unitOfWork.Save();
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
            //var categoryFromDb = _db.Categories.Find(id);
            var CategoryFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            // var CategoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (CategoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(CategoryFromDbFirst);
        }
        //Post
        [HttpPost,ActionName("Delete")]// for using ActionName("Delete") you can use Delete instead of DeletePost().
        [ValidateAntiForgeryToken]//help and prevent the cross site forgery attacks.
        public IActionResult DeletePost(int?id)
        {
            var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            
                _unitOfWork.Category.Remove(obj);
                _unitOfWork.Save();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");

            return View();  
        }
    }
}
