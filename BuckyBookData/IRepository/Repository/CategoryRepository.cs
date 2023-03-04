using BuckyBookWeb.DataAccess;
using BuckyBookWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckyBookDataAccess.IRepository.Repository
{
    // use to implement ICategory 
    public class CategoryRepository : Repository<Category>, ICategoryRespository
    {
        // inherit the class Repository<Category> due to it contains the implementation of interface IRepository which is generic functionality.
        // ICategoryRespository interface inherits IRepository interface 

        //inject the application DBContext using dependency injection
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db) 
        {
            // pass the db object to the base class
            // because the Respository expects db context object
            _db = db;
        }

        // now we need to implements the remaining Methods which we declared in ICategoryRespository
        public void Save()
        {
            _db.SaveChanges();  
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
