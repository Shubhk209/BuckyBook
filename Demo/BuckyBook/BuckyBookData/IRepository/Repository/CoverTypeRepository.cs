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
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRespository
    { 

        //inject the application DBContext using dependency injection
        private ApplicationDbContext _db;

        public CoverTypeRepository(ApplicationDbContext db) : base(db) 
        {
            // pass the db object to the base class
            // because the Respository expects db context object
            _db = db;
        }

        // now we need to implements the remaining Methods which we declared in ICategoryRespository
        

        public void Update(CoverType obj)
        {
            _db.CoverTypes.Update(obj);
        }
    }
}
