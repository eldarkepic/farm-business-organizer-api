using farma_api.Models;
using Microsoft.EntityFrameworkCore;


namespace farma_api.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariation> ProductVariations { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        
    }
}
