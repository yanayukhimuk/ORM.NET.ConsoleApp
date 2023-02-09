using Azure.Core;
using ORM.NET.Library.DataAccess;
using ORM.NET.Library.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ORM.NET.Library;

namespace ORM.NET.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var actionOnDB = new ActionOnDB();

            var localProduct1 = new Product(1, "Milk", "Cow milk", (decimal)1.1, (decimal)1, (decimal)1, (decimal)1);
            var localProduct2 = new Product(2, "Milk", "Goat milk", (decimal)1.1, (decimal)1, (decimal)1, (decimal)1);
            var localProduct3 =
                new Product(3, "Cheese", "Cow cheese", (decimal)1.1, (decimal)1, (decimal)1, (decimal)1);
            var localProduct4 =
                new Product(4, "Cheese", "Goat cheese", (decimal)1.1, (decimal)1, (decimal)1, (decimal)1);

            var localProducts = new List<Product>() { localProduct1, localProduct2, localProduct3, localProduct4 };

            var localOrder = new Order(1, 1, DateTime.Now, DateTime.Today, localProducts);
            var localOrder2 = new Order(2, 2, DateTime.Now, DateTime.Today, localProducts);

            var localOrders = new List<Order>() { localOrder, localOrder2 };

            var ordersToUpload = actionOnDB.PrepareOrdersForUpload(localProducts, localOrders);

            UploadOrders(ordersToUpload);
            RemoveOrder(1);

        }

        public static void UploadOrders(List<Order> orders)
        {
            var context = new MyDbContext();
            context.Orders.AddRange(orders);
            context.SaveChanges();
        }

        public static void RemoveOrder(int orderIndex)
        {
            var context = new MyDbContext();
            var orderToDelete = context.Orders.ElementAt(orderIndex);
            context.Orders.Remove(orderToDelete);
            context.SaveChanges();
        }

        public static void UploadProducts(List<Product> products)
        {
            var context = new MyDbContext();
            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}