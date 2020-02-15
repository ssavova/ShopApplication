namespace Andreys.Data
{
    using Andreys.Models;
    using Microsoft.EntityFrameworkCore;

    public class AndreysDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Andrey;Integrated Security=True;");
        }
       
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

    }
}
