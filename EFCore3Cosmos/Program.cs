using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore3Cosmos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting EF 3 Cosmos Test client....");
            Console.WriteLine("Creating DB..");
            CreateDB();

            Console.WriteLine("Adding an order...");
            AddOrder();

            Console.WriteLine("Adding Order with order items...");
            AddOrderWithItems();

            Console.WriteLine("Show Orders with items...");
            ShowOrders();

            Console.WriteLine("Show Orders with order items...");
            ShowOrderWithItems();

            Console.WriteLine("Searching orders from John...");
            ShowOrder("John");

            Console.WriteLine("Press any key to exit....");
            Console.ReadKey();
        }

        private static void CreateDB()
        {
            using (var context = new OrderDbContext())
            {
                context.Database.EnsureCreated();
            }
        }

        private static void AddOrder()
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Customer = "John"
            };

            using (var context = new OrderDbContext())
            {
                context.Add(order);
                context.SaveChanges();
            };
        }


        private static void AddOrderWithItems()
        {
            var orderId = Guid.NewGuid();
            var order = new Order
            {
                Id = orderId,
                Customer = "John"
            };

            order.OrderItems.Add(
            new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                Item="Apple",
                Quntity =  10
            });

            using(var context = new OrderDbContext())
            {
                context.Add(order);
                context.SaveChanges();
            }
        }

        private static void ShowOrders()
        {
            List<Order> orders;
            using (var context= new OrderDbContext())
            {
                orders = context.Orders.ToList(); 
            }

            if (orders == null) return;

            Console.WriteLine("Orders....");
            foreach (var order in orders)
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(order));
            }
        }

        private static void ShowOrderWithItems()
        {
            List<Order> orders;
            using (var context = new OrderDbContext())
            {
                orders = context.Orders.Include(c=> c.OrderItems).ToList();
            }

            if (orders == null) return;

            Console.WriteLine("Orders....");
            foreach (var order in orders)
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(order));
            }
        }      

        private static void ShowOrder(string customer)
        {
            Order order;
            using (var context = new OrderDbContext())
            {
                order = context.Orders.FirstOrDefault(c => c.Customer.Contains(customer));
            }

            if (order == null)
            {
                Console.WriteLine($"Order from {customer}  not avalable in db");
                return;
            }

            Console.WriteLine("Order found....");          
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(order));            
        }
    }
}
