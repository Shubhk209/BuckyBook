

using BuckyBookWeb.Models;

namespace BuckyBookDataAccess.IRepository
{
    public interface ICoverTypeRespository : IRepository<CoverType>

    {
        // to update the category we implemnt the this method.
        void Update(CoverType obj);
        //to explicitly call when we want to save the changes to DB.
        
    }
}
