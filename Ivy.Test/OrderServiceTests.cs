using System;
using Ivy.Entities;
using Ivy.Services;
using Xunit;

namespace Ivy.Test
{
    public class OrderServiceTests
    {
        [Fact]
        public void Can_Order_Products_Available()
        {
            var inventory = new InventoryService();
            var pencil = inventory.Add(5, "Pencil", 1, 0.1m);
            var paper = inventory.Add(8, "Paper", 100, 2);

            var orderService = new OrderService(inventory);
            var order = orderService.Create();

            order.Add(1, pencil);
            order.Add(2, paper);

            orderService.Fulfill(order);
            
            Assert.Equal(OrderStatus.Fulfilled, order.Status);
        }

        [Fact]
        public void Cannot_Order_If_Not_In_Stock()
        {
            var inventory = new InventoryService();
            var pencil = inventory.Add(5, "Pencil", 1, 0.1m);
            
            var orderService = new OrderService(inventory);
            var order = orderService.Create();

            order.Add(6, pencil);

            var exception = Assert.Throws<OrderException>(() => orderService.Fulfill(order));
            Assert.Contains("out of stock", exception.Message, StringComparison.OrdinalIgnoreCase);
        }
    }
}