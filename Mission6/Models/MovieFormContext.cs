using Microsoft.EntityFrameworkCore;
using Mission06_Webster.Models;

namespace Mission6.Models
{
    public class MovieFormContext : DbContext
    {
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base (options) 
        { 
        }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) //Seed Data
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Sci-Fi" },
                new Category { CategoryId = 2, CategoryName = "Drama" },
                new Category { CategoryId = 3, CategoryName = "Comedy" },
                new Category { CategoryId = 4, CategoryName = "Horror" },
                new Category { CategoryId = 5, CategoryName = "Action" },
                new Category { CategoryId = 6, CategoryName = "Adventure" },
                new Category { CategoryId = 7, CategoryName = "Other" }
            );
        }
    }
}
