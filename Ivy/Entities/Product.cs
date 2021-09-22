namespace Ivy.Entities
{
    /// <summary>
    /// Stores a single product in our system
    /// </summary>
    public class Product
    {
        public Product(string name)
        {
            Name = name;
        }
        
        public string Name { get; set; }
        
        /// <summary>
        /// In grams
        /// </summary>
        public decimal? Weight { get; set; }
        
        /// <summary>
        /// In dollars
        /// </summary>
        public decimal? Price { get; set; }
    }
}