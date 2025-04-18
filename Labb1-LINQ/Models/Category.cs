﻿using System.ComponentModel.DataAnnotations;

namespace Labb1_LINQ.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        //Navigational Properties
        public ICollection<Product> Products { get; set; } = null!;
    }
}