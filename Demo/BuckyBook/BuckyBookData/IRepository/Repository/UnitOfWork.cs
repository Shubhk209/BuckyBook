using BuckyBookWeb.DataAccess;

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
            CoverType = new CoverTypeRepository(_db);

        }

        // property
        public ICategoryRespository Category { get; private set; }
        public ICoverTypeRespository CoverType { get; private set; }

        //method
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
