using System.ComponentModel.DataAnnotations;

namespace SportsProductApi.DTO
{
    public class ProductCreateDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int StockAvailable { get; set; }

        public string? Description { get; set; }

        public string? Category { get; set; }

        public string? Brand { get; set; }

        public string? Player { get; set; }
    }
}
