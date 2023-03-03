using BuckyBookWeb.DataAccess;
using BuckyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BuckyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> list = _db.Categories.ToList();
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
                // add the entry to db
                _db.Categories.Add(obj);

                // push the changes to db
                _db.SaveChanges();

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
            var CategoryFromDb = _db.Categories.Find(id);
            //var CategoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            //var CategoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);

            // check if fetch data is null 
            if (CategoryFromDb == null)
                return NotFound();


            // if fetch data is not null then return data to view
            return View(CategoryFromDb);
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
				_db.Categories.Update(obj);

				// push the changes to db
				_db.SaveChanges();
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
			var CategoryFromDb = _db.Categories.Find(id);
			//var CategoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
			//var CategoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);

			// check if fetch data is null 
			if (CategoryFromDb == null)
				return NotFound();


			// if fetch data is not null then return data to view
			return View(CategoryFromDb);
		}

        //Now we can use Delete as Action method for post request.
		[HttpPost,ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePost(int? id)
		{

            var obj = _db.Categories.Find(id);

            if(obj == null)
            {
                return NotFound();
            }

			
			// remove the record based on primary key to db
			_db.Categories.Remove(obj);

			// push the changes to db
			_db.SaveChanges();
            // for success alert
			TempData["Success"] = "Category deleted successfully";
			
            return RedirectToAction("Index");
			
			
		}
	}
}
