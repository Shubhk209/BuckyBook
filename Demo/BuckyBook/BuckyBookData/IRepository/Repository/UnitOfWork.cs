using BuckyBookWeb.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckyBookDataAccess.IRepository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        //inject the application DBContext using dependency injection
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db) 
        {
            // pass the db object to the base class
            // because the Respository expects db context object
            _db = db;
            // create object of CategoryRepository
            Category = new CategoryRepository(_db);

        }

        // property
        public ICategoryRespository Category { get; private set; }

        //method
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
