using System.ComponentModel.DataAnnotations;

namespace Labb1_LINQ.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        //Navigational Properties
        public Order Order { get; set; } = null!;

        public Product Product { get; set; } = null!;
    }
}
