using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BuckyBookDataAccess.IRepository
{
    public interface IUnitOfWork
    {
        // Create all repository 
        ICategoryRespository CategoryRepo { get; }

        // Global method
        void Save();
        

        }
    
}
