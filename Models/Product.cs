using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SportsProductApi.Models
{
    public class Product
    {
        [Key]
        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } // e.g. "Cricket Bat", "Tennis Racket", "Running Shoes"

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int StockAvailable { get; set; }

        public string Description { get; set; } // e.g. "Nike Air Zoom Pegasus"

        public string Category { get; set; } // e.g. "Cricket", "Tennis", "Running"

        public string Brand { get; set; } // e.g. "Adidas", "Yonex", "SG"

        public string Player { get; set; } // e.g. "Virat Kohli"
    }

    // DbContext
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }

}
