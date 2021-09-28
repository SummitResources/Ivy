using System;
using System.Collections.Generic;
using Ivy.Entities;

namespace Ivy.Services
{
    /// <summary>
    /// Class that stores a list of products and quantity available for each product
    /// </summary>
    public class InventoryService
    {
        // quantity -> Product
        public List<InventoryItem> Items { get; } = new();

        public InventoryItem? Find(string name)
        {
            foreach (var item in Items)
            {
                if (item.Product.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }

            return null;
        }

        public Product Add(int quantity, string name, decimal weight, decimal price)
        {
            var product = new Product(name) { Price = price, Weight = weight };
            Items.Add(new InventoryItem(product, quantity));
            return product;
        }
    }
}