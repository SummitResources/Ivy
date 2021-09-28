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

        [Theory]
        [InlineData(1,  1, 1)]  //  1 product  x  1g each =   1g = $1
        [InlineData(1,  1, 40)] //  1 product  x 40g each =  40g = $1
        [InlineData(1,  2, 40)] //  2 products x 40g each =  80g = $1
        [InlineData(1,  3, 30)] //  3 products x 30g each =  90g = $1
        [InlineData(2,  4, 30)] //  4 products x 30g each = 120g = $2
        [InlineData(2,  4, 40)] //  4 products x 40g each = 160g = $2
        [InlineData(3,  5, 50)] //  5 products x 50g each = 250g = $3
        [InlineData(4,  6, 50)] //  6 products x 50g each = 300g = $4
        [InlineData(5,  7, 70)] //  7 products x 70g each = 490g = $5
        [InlineData(6,  8, 70)] //  8 products x 70g each = 560g = $6
        [InlineData(6,  9, 70)] //  9 products x 70g each = 630g = $6
        [InlineData(7, 10, 70)] // 10 products x 70g each = 700g = $7
        [InlineData(7, 11, 70)] // 11 products x 70g each = 770g = $7
        [InlineData(7, 12, 70)] // 12 products x 70g each = 840g = $7
        [InlineData(8, 13, 70)] // 13 products x 70g each = 910g = $8
        public void Calculate_Shipping_Cost_Single_Product(decimal cost, int productQuantity, decimal productWeight)
        {
            var inventory = new InventoryService();
            var firstProduct = inventory.Add(productQuantity, "Pencil", productWeight, price: 0 /* irrelevant for this test */);

            var orderService = new OrderService(inventory);
            var order = orderService.Create();
            order.Add(productQuantity, firstProduct);
            
            Assert.Equal(cost, orderService.CalculateShippingCost(order));
        }
    }
}