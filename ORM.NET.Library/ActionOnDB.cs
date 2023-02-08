using ORM.NET.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using ORM.NET.Library.DataAccess;
using System.Security.Cryptography;

namespace ORM.NET.Library
{
    public class ActionOnDB
    {
        public Order CreateOrderForDb(Order order, List<Product> products)
        {
            return new Order()
            {
                Status = order.Status,
                CreatedDate = order.CreatedDate,
                UpdatedDate = order.UpdatedDate,
                Products = products
            };
        }

        public Product CreateProductForDb(Product product)
        {
            return new Product()
            {
                Name = product.Name,
                Description = product.Description,
                Weight = product.Weight,
                Height = product.Height,
                Width = product.Width,
                Length = product.Length
            };
        }

        public List<Order> PrepareOrdersForUpload(DbContext dbContext, List<Product> productsList, List<Order> orderList)
        {
            var products = new List<Product>();
            var orders = new List<Order>();
            foreach (var product in productsList)
            {
                var productForDb = CreateProductForDb(product);
                products.Add(productForDb);
            }

            foreach (var order in orderList)
            {
                var orderForDb = CreateOrderForDb(order, products);
                orders.Add(orderForDb);
            }

            return orders;
        }
    }
}
