using System;
using System.Collections.Generic;
using Ivy.Entities;

namespace Ivy.Services
{
    public class InventoryService
    {
        // quantity -> Product
        public Dictionary<int, Product> Items { get; } = new();

        public Product? Find(string name)
        {
            foreach (var product in Items.Values)
            {
                if (product.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return product;
                }
            }

            return null;
        }

        public Product Add(int quantity, string name, decimal weight, decimal price)
        {
            var product = new Product(name) { Price = price, Weight = weight };
            Items.Add(quantity, product);
            return product;
        }
    }
}