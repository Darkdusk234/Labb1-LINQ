using System.ComponentModel.DataAnnotations;

namespace Labb1_LINQ.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string ContactPerson { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string? Phone {  get; set; }
    }
}