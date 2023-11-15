using CocPla.Models;
using Microsoft.EntityFrameworkCore;

namespace CocPla.DAO
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Chef> Cocineros { get; set; }
    }
}
