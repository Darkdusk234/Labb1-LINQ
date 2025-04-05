using System.ComponentModel.DataAnnotations;

namespace Labb1_LINQ.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal Price { get; set; } = 0;

        public int StockQuantity { get; set; } = 0;

        public int CategoryId { get; set; }

        public int SupplierId { get; set; }


        //Navigation Properties
        public Category Category { get; set; } = null!;

        public Supplier Supplier { get; set; } = null!;
    }
}
