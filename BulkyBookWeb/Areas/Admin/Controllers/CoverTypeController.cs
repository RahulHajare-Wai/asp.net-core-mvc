using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //it will retrive all of the categories from database and convert it into the list.
            IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll(); 
            return View(objCoverTypeList);
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
        public IActionResult Create(CoverType obj)
        {
            
            
            if(ModelState.IsValid)
            {
            _unitOfWork.CoverType.Add(obj);
            _unitOfWork.Save();
             TempData["success"] = "Cover Type created Successfully";
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
            var CoverTypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            // var CategoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (CoverTypeFromDbFirst == null)
            {
                return NotFound();
            }
            return View(CoverTypeFromDbFirst);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]//help and prevent the cross site forgery attacks.
        public IActionResult Edit(CoverType obj)
        {
            
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                TempData["success"] = "Cover Type Updated Successfully";

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
            var CoverTypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            // var CategoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (CoverTypeFromDbFirst == null)
            {
                return NotFound();
            }
            return View(CoverTypeFromDbFirst);
        }
        //Post
        [HttpPost,ActionName("Delete")]// for using ActionName("Delete") you can use Delete instead of DeletePost().
        [ValidateAntiForgeryToken]//help and prevent the cross site forgery attacks.
        public IActionResult DeletePost(int?id)
        {
            var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            
                _unitOfWork.CoverType.Remove(obj);
                _unitOfWork.Save();
            TempData["success"] = "Cover Type Deleted Successfully";
            return RedirectToAction("Index");

            return View();  
        }
    }
}
