namespace SpaStore.Services
{
    using System.Collections.Generic;
    using Models;

    /// <summary> Service to retrieve the product inventory. </summary>
    public class ProductService : IProductService
    {
        /// <inheritdoc />
        public IList<Product> GetProducts()
        {
            IList<Product> products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Butter",
                    Price = 0.8m
                },
                new Product
                {
                    Id = 2,
                    Name = "Milk",
                    Price = 1.15m
                },
                new Product
                {
                    Id = 3,
                    Name = "Bread",
                    Price = 1m
                }
            };

            return products;
        }
    }
}
