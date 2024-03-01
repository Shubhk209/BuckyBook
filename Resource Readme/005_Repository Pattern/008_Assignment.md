# Assignment - 1

- Create Cover Type Model/ Table
  - Id (Primary Key)
  - Name
- Push CoverType to Database
- Implement CoverType Respository and perform CRUD operation using UnitOfWOrk

# Create a Model CoverType (1)

Add a class file named with CoverType in `BulkyBook.Model` repository.

```c#
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuckyBookModels
{
    public class CoverType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name="Cover Type")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}

```

# Add DBset in ApplicatonDbContext file (2)

Add Property to represent Table in the database in DBContext class.

```c#
using BuckyBookModels;
using BuckyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BuckyBookWeb.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        // create db sets which we want to create
        public DbSet<Category> Categories { get; set; } = default!;

        public DbSet<CoverType> CoverTypes { get; set; } = default!;
    }
}

```

# Add Migration (3)

Open the Package Manager console.

```bash
add-migration AddCoverTypeToDB

update-database
```

# Create ICoverTypeRespository interface in DataAccess Repository (4)

```c#
using BuckyBookModels;

namespace BuckyBookDataAccess.IRepository
{
    public interface ICoverTypeRespository : IRepository<CoverType>

    {
        // to update the category we implemnt the this method.
        void Update(CoverType obj);
        //to explicitly call when we want to save the changes to DB.

    }
}

```

# Add Property in the UnitOfWork Class

```c#
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
```
