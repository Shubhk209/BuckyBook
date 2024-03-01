using BuckyBookDataAccess.IRepository;
using BuckyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuckyBookWeb.Areas.Admin.Controllers
{
    public class CoverTypeController : Controller
    {
        //private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<CoverType> list = _unitOfWork.CoverType.GetAll();
            return View(list);
        }

        //GET
        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
           

            // check if model is valid
            if (ModelState.IsValid)
            {
                // add the entry to db by using Repository implemented method
                _unitOfWork.CoverType.Add(obj);

                // push the changes to db using CategoryRepository implemented method
                _unitOfWork.Save();

                TempData["Success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            // check if id is valid or not
            if (id == null || id == 0)
                return NotFound();


            // fetch the category details
            //var CategoryFromDb = _db.Find(id);
            //var CategoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            var CoverTypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

            // check if fetch data is null 
            if (CoverTypeFromDbFirst == null)
                return NotFound();


            // if fetch data is not null then return data to view
            return View(CoverTypeFromDbFirst);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {

            if (obj.Name == obj.Name.ToString())
            {
                ModelState.AddModelError("CustomError", "The display order cannot exactly match the name");
            }

            // check if model is valid
            if (ModelState.IsValid)
            {
                // update the record based on primary key to db
                _unitOfWork.CoverType.Update(obj);

                // push the changes to db
                _unitOfWork.Save();
                TempData["Success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            // check if id is valid or not
            if (id == null || id == 0)
                return NotFound();


            // fetch the category details
            //var CategoryFromDb = _db.Categories.Find(id);
            //var CategoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            var CategoryFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

            // check if fetch data is null 
            if (CategoryFromDbFirst == null)
                return NotFound();


            // if fetch data is not null then return data to view
            return View(CategoryFromDbFirst);
        }

        //Now we can use Delete as Action method for post request.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {

            var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }


            // remove the record based on primary key to db
            _unitOfWork.CoverType.Remove(obj);

            // push the changes to db
            _unitOfWork.Save();
            // for success alert
            TempData["Success"] = "Category deleted successfully";

            return RedirectToAction("Index");


        }
    }
}
