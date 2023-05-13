using BuckyBookWeb.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace BuckyBookDataAccess.IRepository.Repository
{
    // it is a generic class 
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        // constructor to inject DbContext
        public Repository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
            // From DbContext, we will get the DbSet and work on that directly.
            // set our dbSet to the particular instance of the class
            dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {

            // dbset is basically working same as _db.Categories.Add(obj)
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {

            IQueryable<T> query = dbSet;

            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;

            // return a filter data from which we get first record in next statement.
            query = query.Where(filter);

            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
