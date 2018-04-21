namespace SpaStore.Test.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using NSubstitute;
    using SpaStore.Controllers;
    using SpaStore.Models;
    using SpaStore.Services;
    using Xunit;

    public class BasketControllerTest
    {
        [Fact]
        public void AddBasket_ReturnsTheBasketId()
        {
            IProduct fakeButter = new Product
            {
                Id = 1,
                Name = "Butter",
                Price = 0.8m
            };

            IBasket basket = new Basket();

            basket.Items.Add(fakeButter);

            BasketController controller = new BasketController();

            Assert.IsType<Guid>(controller.AddBasket(basket));
        }

        [Fact]
        public void GetBasketPrice_ReturnsThePriceOfTheBasket()
        {
            Guid guid = Guid.NewGuid();

            var mockController = Substitute.For<BasketController>();
            mockController.AddBasket(Arg.Any<IBasket>()).Returns(guid);

            IProduct fakeButter = new Product
            {
                Id = 1,
                Name = "Butter",
                Price = 0.8m
            };

            IBasket basket = new Basket();

            basket.Items.Add(fakeButter);

            BasketController controller = new BasketController();

            controller.AddBasket(basket);

            var result = controller.GetBasketPrice(guid);

            Assert.Equal(0.8m, result);
        }

        [Fact]
        public void GetBasketPrice_InvalidBasketId_Returns404()
        {
            BasketController controller = new BasketController();

            var exception = controller.GetBasketPrice(Guid.NewGuid());

            Assert.IsType<NotFoundResult>(exception);
        }
    }
}
