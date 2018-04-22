namespace SpaStore.Test.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using NSubstitute;
    using NSubstitute.ReturnsExtensions;
    using SpaStore.Controllers;
    using SpaStore.Models;
    using SpaStore.Services;
    using Utils;
    using Xunit;

    public class BasketControllerTest
    {
        private readonly IProductService fakeProductService;
        private readonly IBasketCalculatorService fakeService;
        private readonly BasketController controller;

        public BasketControllerTest()
        {
            fakeProductService = Substitute.For<IProductService>();
            fakeProductService.GetProducts().ReturnsForAnyArgs(new List<Product>());
            fakeService = Substitute.For<BasketCalculatorService>(fakeProductService);

            controller = new BasketController(fakeService);
        }

        [Fact]
        public void AddBasket_NullBasket_CreatesABasketAndReturnsTheBasket()
        {
            var basket = controller.AddBasket(null);

            Assert.NotNull(basket);
            Assert.IsType<Guid>(basket.Id);
        }

        [Fact]
        public void AddBasket_ReturnsTheBasket()
        {
            Product fakeButter = new Product
            {
                Id = 1,
                Name = "Butter",
                Price = 0.8m
            };

            Basket basket = new Basket();

            basket.Items.Add(fakeButter);

            var result = controller.AddBasket(basket);

            Assert.Same(fakeButter, result.Items[0]);
        }

        [Fact]
        public void GetBasketPrice_ReturnsThePriceOfTheBasket()
        {
            Guid guid = Guid.NewGuid();

            IBasket basket = new Basket { Id = guid, Items = { new Product { Id = 1, Price = 0.8m } } };
            fakeService.Baskets = new List<IBasket> { basket };

            var result = controller.GetBasketPrice(guid);

            Assert.Equal(0.8m, result);
        }

        [Fact]
        public void GetBasketPrice_InvalidBasketId_ThrowsException()
        {
            fakeService.Baskets = new List<IBasket>();

            ActionResultException exception = Assert.Throws<ActionResultException>(() => controller.GetBasketPrice(Guid.NewGuid()));

            Assert.IsType<NotFoundResult>(exception.Result);
        }
    }
}
