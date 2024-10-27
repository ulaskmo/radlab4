using Microsoft.EntityFrameworkCore;
using radlab4._0.Models;

namespace radlab4._0.Data
{
    public class AdDbContext : DbContext
    {
        public AdDbContext(DbContextOptions<AdDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ad> Ads { get; set; }
        public DbSet<Seller> Sellers { get; set; }   // Add this line for Sellers
        public DbSet<Category> Categories { get; set; }  // Add this line for Categories
    }
}