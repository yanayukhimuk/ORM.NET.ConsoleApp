using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.NET.Library.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<Product> Products { get; set; }

        public Order(int orderId, int status, DateTime createdDate, DateTime updatedDate, List<Product> products)
        {
            OrderId = orderId;
            Status = status;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            Products = products;    
        }

        public Order(){}
    }
}
