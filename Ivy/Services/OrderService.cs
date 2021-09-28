using System;
using Ivy.Entities;

namespace Ivy.Services
{
    /// <summary>
    /// Class that allows us to place orders with all the necessary validations 
    /// </summary>
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
            foreach (var item in order.Items)
            {
                var inventory = _inventoryService.Find(item.Product.Name);
                if (inventory is null)
                {
                    throw new OrderException($"Could not find product '{item.Product.Name}' in inventory");
                }
                
                // TODO ensure the quantity is available
            }

            order.Status = OrderStatus.Fulfilled;
        }
    }
}