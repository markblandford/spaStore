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
        private IBasketCalculatorService fakeService;
        private BasketController controller;

        public BasketControllerTest()
        {
            fakeService = Substitute.For<IBasketCalculatorService>();

            controller = new BasketController(fakeService);
        }

        [Fact]
        public void AddBasket_NullBasket_CreatesABasketAndReturnsTheBasketWithAnId()
        {
            var basket = controller.AddBasket(null);

            Assert.IsType<Guid>(basket.Id);
        }

        [Fact]
        public void AddBasket_ReturnsTheBasketWithAnId()
        {
            IProduct fakeButter = new Product
            {
                Id = 1,
                Name = "Butter",
                Price = 0.8m
            };

            IBasket basket = new Basket();

            basket.Items.Add(fakeButter);

            var result = controller.AddBasket(basket);

            Assert.Same(fakeButter, result.Items[0]);
            Assert.IsType<Guid>(result.Id);
        }

        [Fact]
        public void GetBasketPrice_ReturnsThePriceOfTheBasket()
        {
            Guid guid = Guid.NewGuid();

            IBasket basket = new Basket { Id = guid };
            fakeService.Baskets = new List<IBasket> { basket };

            fakeService.CalculateBasketPrice(basket).Returns(0.8m);

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
