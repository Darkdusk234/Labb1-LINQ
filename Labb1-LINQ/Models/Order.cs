using System.ComponentModel.DataAnnotations;

namespace Labb1_LINQ.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string OrderDate { get; set; } = string.Empty;

        public int CustomerId { get; set; }

        public decimal TotalAmount { get; set; }

        public string? Status { get; set; }

        //Navigation Properties
        public Customer Customer { get; set; }
    }
}