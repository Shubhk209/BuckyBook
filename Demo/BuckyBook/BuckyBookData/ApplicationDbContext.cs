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
