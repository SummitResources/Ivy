using System.Collections.Generic;

namespace Ivy.Entities
{
    /// <summary>
    /// Manages an order and associated data placed from our application
    /// </summary>
    public class Order
    {
        public Order(string id, OrderStatus status)
        {
            Id = id;
            Status = status;
        }

        public string Id { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; } = new();

        public void Add(int quantity, Product product)
        {
            Items.Add(new OrderItem(product, quantity));
        }
    }
    
    public enum OrderStatus { Created, Fulfilled }
}