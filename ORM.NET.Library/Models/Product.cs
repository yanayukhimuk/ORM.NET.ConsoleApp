using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.NET.Library.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }

        public Product(int productId, string? name, string? description, decimal weight, decimal height, decimal width, decimal length)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Weight = weight;
            Height = height;
            Width = width;
            Length = length;    
        }

        public Product()
        {
                
        }
    }
}
