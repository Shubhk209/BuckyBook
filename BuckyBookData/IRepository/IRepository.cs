using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BuckyBookDataAccess.IRepository
{
    public interface IRepository<T> where T : class
    {
       // it is a generic repository
       // assume T is Category class
       // define All the common methods that we want to implement

        // Expression of type Function of T class, boolean for linq expression
        T GetFirstOrDefault(Expression<Func<T,bool>> filter );
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
