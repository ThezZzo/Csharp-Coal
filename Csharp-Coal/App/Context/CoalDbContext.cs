using Csharp_Coal.App.Interfaces;
using Csharp_Coal.App.Models;
using Microsoft.EntityFrameworkCore;

namespace Csharp_Coal.App.Context;

public class CoalDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<SizeCoal> SizeCoals { get; set; }
    public DbSet<CategorySize> CategorySizes { get; set; }

    public CoalDbContext(DbContextOptions<CoalDbContext> options) : base(options)
    {
        
    }
    public CoalDbContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=coalDB;Username=postgres;Password=admin");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Category cat1 = new Category { Id = 1, Name = "Длиннопламенный", Carbon = 70, Volatiles = 50, Heat = "6500-7500" };
        Category cat2 = new Category { Id = 2, Name = "Бурый", Carbon = 65, Volatiles = 45, Heat = "4500-5500" };

        SizeCoal siz1 = new SizeCoal { Id = 1, Name = "Крупный", Size = "более 100мм" };
        SizeCoal siz2 = new SizeCoal { Id = 2, Name = "Рядовой", Size = "не имеет ограничений"};

        CategorySize catsiz1 = new CategorySize { CategoryId = cat1.Id, SizeCoalId = siz1.Id };
        CategorySize catsiz2 = new CategorySize { CategoryId = cat1.Id, SizeCoalId = siz2.Id };
        CategorySize catsiz3 = new CategorySize { CategoryId = cat2.Id, SizeCoalId = siz1.Id };
        CategorySize catsiz4 = new CategorySize { CategoryId = cat2.Id, SizeCoalId = siz2.Id };
        
        modelBuilder.Entity<CategorySize>().HasKey(cs => new { cs.CategoryId, cs.SizeCoalId});
        modelBuilder.Entity<Category>().HasData(cat1, cat2);
        modelBuilder.Entity<SizeCoal>().HasData(siz1, siz2);
        modelBuilder.Entity<CategorySize>().HasData(catsiz1, catsiz2, catsiz3, catsiz4);
    }
    
    public class Category
    {

        public int Id { get; set; }
    
        public string Name { get; set; }
    
        public int Carbon { get; set; }

        public int Volatiles { get; set; } 
    
        public string Heat { get; set; }
        
    }
    
    public class SizeCoal
    {

        public int Id { get; set; } 
        public string Name { get; set; } = null!;

        public string Size { get; set; } = null!;
        
    }
    
    public class CategorySize
    {

    
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    
        public int SizeCoalId { get; set; }
    
        public SizeCoal SizeCoal { get; set; }
        
    }
}