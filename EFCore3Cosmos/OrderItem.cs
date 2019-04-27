using System;

namespace EFCore3Cosmos
{
    public class OrderItem
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public string Item { get; set; }

        public decimal Quntity { get; set; }
    }
}