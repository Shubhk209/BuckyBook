using BuckyBookDataAccess.IRepository;
using BuckyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuckyBookWeb.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        //private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> list = _unitOfWork.Category.GetAll();
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
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The display order cannot exactly match the name");
            }

            // check if model is valid
            if (ModelState.IsValid)
            {
                // add the entry to db by using Repository implemented method
                _unitOfWork.Category.Add(obj);

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
            var CategoryFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

            // check if fetch data is null 
            if (CategoryFromDbFirst == null)
                return NotFound();


            // if fetch data is not null then return data to view
            return View(CategoryFromDbFirst);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The display order cannot exactly match the name");
            }

            // check if model is valid
            if (ModelState.IsValid)
            {
                // update the record based on primary key to db
                _unitOfWork.Category.Update(obj);

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
            var CategoryFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

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

            var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }


            // remove the record based on primary key to db
            _unitOfWork.Category.Remove(obj);

            // push the changes to db
            _unitOfWork.Save();
            // for success alert
            TempData["Success"] = "Category deleted successfully";

            return RedirectToAction("Index");


        }
    }
}
