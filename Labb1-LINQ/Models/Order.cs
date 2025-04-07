using System.ComponentModel.DataAnnotations;

namespace Labb1_LINQ.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        public decimal TotalAmount { get; set; }

        public string? Status { get; set; }

        //Navigation Properties
        public Customer Customer { get; set; }
    }
}