namespace SpaStore.Test.Controllers
{
    using System.Collections.Generic;
    using NSubstitute;
    using SpaStore.Controllers;
    using SpaStore.Models;
    using SpaStore.Services;
    using Xunit;

    public class ProductControllerTest
    {
        private readonly IProductService fakeProductService;
        private readonly ProductController controller;

        public ProductControllerTest()
        {
            fakeProductService = Substitute.For<IProductService>();
            fakeProductService.GetProducts().ReturnsForAnyArgs(new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Butter",
                    Price = 0.8m
                }
            });

            controller = new ProductController(fakeProductService);
        }

        [Fact]
        public void GetProducts_ReturnsTheProducts()
        {
            var result = controller.GetProducts();

            Assert.Equal(1, result[0].Id);
            Assert.Equal("Butter", result[0].Name);
            Assert.Equal(0.8m, result[0].Price);
        }

    }
}
