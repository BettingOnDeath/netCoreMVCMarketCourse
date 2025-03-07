﻿using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;

namespace MVCMarketCourse.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        
        [Required]
        public string Name { get; set; }  = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}
