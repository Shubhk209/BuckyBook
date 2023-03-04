using BuckyBookWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckyBookDataAccess.IRepository
{
    internal interface ICategoryRespository : IRepository<Category>
    {
        // to update the category we implemnt the this method.
        void Update(Category obj);
        //to explicitly call when we want to save the changes to DB.
        void Save();
    }
}
