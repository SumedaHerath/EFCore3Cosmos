using System;
using System.Collections.Generic;

namespace EFCore3Cosmos
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        public Guid Id { get; set; }

        public string Customer { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}