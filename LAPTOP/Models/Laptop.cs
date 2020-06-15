using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        
        public string CPU { get; set; }
        
        public string Ram { get; set; }
        
        public string Image_laptop { get; set; }
        
        public float Price { get; set; }
        
        public Category Category { get; set; }
        
        public byte CategoryId { get; set; }
        
        public IEnumerable<Category> Categories { get; set; }

        
    }
}
