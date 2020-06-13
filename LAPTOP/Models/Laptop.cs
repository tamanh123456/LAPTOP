using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace LAPTOP.Models
{
    public class Laptop
    {
        public string Id { get; set; }
        public ApplicationUser Admin { get; set; }
        public string AdminId { get; set; }
        [Required]
        public string CPU { get; set; }
        [Required]
        public string Ram { get; set; }
        [Required]
        public string Image_laptop { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public byte CategoryId { get; set; }
        
        public IEnumerable<Category> Categories { get; set; }

        
    }
}
