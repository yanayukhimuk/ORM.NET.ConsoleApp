using Azure.Core;
using ORM.NET.Library.DataAccess;
using ORM.NET.Library.Models;
using System.Collections.Generic;
using ORM.NET.Library;

namespace ORM.NET.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var actionOnDB = new ActionOnDB();
            var context = new MyDbContext();

            var localProduct1 = new Product(1, "Milk", "Cow milk", (decimal)1.1, (decimal)1, (decimal)1, (decimal)1);
            var localProduct2 = new Product(2, "Milk", "Goat milk", (decimal)1.1, (decimal)1, (decimal)1, (decimal)1);
            var localProduct3 = new Product(3, "Cheese", "Cow cheese", (decimal)1.1, (decimal)1, (decimal)1, (decimal)1);
            var localProduct4 = new Product(4, "Cheese", "Goat cheese", (decimal)1.1, (decimal)1, (decimal)1, (decimal)1);

            var localProducts = new List<Product>() { localProduct1, localProduct2, localProduct3, localProduct4 };

            var localOrder = new Order(1, 1, DateTime.Now, DateTime.Today, localProducts);
            var localOrder2 = new Order(2, 2, DateTime.Now, DateTime.Today, localProducts);

            var localOrders = new List<Order>() { localOrder, localOrder2 };

            var ordersToUpload = actionOnDB.PrepareOrdersForUpload(context, localProducts, localOrders);

            using (context)
            {
                context.Orders.AddRange(ordersToUpload);
                context.SaveChanges();
            }

            using (context)
            {
                var orderToDelete = context.Orders.FirstOrDefault();
                context.Orders.Remove(orderToDelete);
                context.SaveChanges();
            }
        }

    }
}