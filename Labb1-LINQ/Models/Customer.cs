using System.ComponentModel.DataAnnotations;

namespace Labb1_LINQ.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;

        public string? Phone { get; set; }

        public string? Adress { get; set; }
    }
}