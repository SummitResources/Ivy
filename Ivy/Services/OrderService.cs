using System;
using Ivy.Entities;

namespace Ivy.Services
{
    public class OrderService
    {
        private readonly InventoryService _inventoryService;

        public OrderService(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        
        public Order Create()
        {
            return new Order(Guid.NewGuid().ToString("N"), OrderStatus.Created);
        }

        public void Fulfill(Order order)
        {
            foreach (var product in order.Products.Values)
            {
                var productInInventory = _inventoryService.Find(product.Name);
                if (productInInventory is null)
                {
                    throw new OrderException($"Could not find product '{product.Name}' in inventory");
                }
                
                // TODO ensure the quantity is available
            }

            order.Status = OrderStatus.Fulfilled;
        }
    }
}