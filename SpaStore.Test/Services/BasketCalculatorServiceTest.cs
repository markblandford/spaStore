namespace SpaStore.Test.Services
{
    using System;
    using Models;
    using NSubstitute;
    using SpaStore.Models;
    using SpaStore.Services;
    using Xunit;

    public class BasketCalculatorServiceTest
    {
        private readonly IProduct fakeButter;
        private readonly IProduct fakeMilk;
        private readonly IProduct fakeBread;

        public BasketCalculatorServiceTest()
        {
            fakeButter = new Product
            {
                Id = 1,
                Name = "Butter",
                Price = 0.8m
            };

            fakeMilk = new Product
            {
                Id = 2,
                Name = "Milk",
                Price = 1.15m
            };

            fakeBread = new Product
            {
                Id = 3,
                Name = "Bread",
                Price = 1m
            };
        }

        [Fact]
        public void CalculateBasketPrice_BasketIsEmpty_ReturnsZero()
        {
            IBasket basket = new Basket();

            IBasketCalculatorService calculator = new BasketCalculatorService();

            Assert.Equal(0m, calculator.CalculateBasketPrice(basket));
        }

        [Fact]
        public void CalculateBasketPrice_BasketHasOneOfEachProduct_ReturnsCorrectTotal()
        {
            IBasket basket = new Basket();

            basket.Items.Add(fakeButter);
            basket.Items.Add(fakeMilk);
            basket.Items.Add(fakeBread);

            IBasketCalculatorService calculator = new BasketCalculatorService();

            Assert.Equal(2.95m, calculator.CalculateBasketPrice(basket));
        }

        [Fact]
        public void CalculateBasketPrice_BasketHasTwoButterAndTwoBread_ReturnsCorrectTotalAfterOffer()
        {
            IBasket basket = new Basket();

            basket.Items.Add(fakeButter);
            basket.Items.Add(fakeButter);
            basket.Items.Add(fakeBread);
            basket.Items.Add(fakeBread);

            IBasketCalculatorService calculator = new BasketCalculatorService();

            Assert.Equal(3.1m, calculator.CalculateBasketPrice(basket));
        }

        [Fact]
        public void CalculateBasketPrice_BasketHasFourMilk_ReturnsCorrectTotalAfterOffer()
        {
            IBasket basket = new Basket();

            basket.Items.Add(fakeMilk);
            basket.Items.Add(fakeMilk);
            basket.Items.Add(fakeMilk);
            basket.Items.Add(fakeMilk);

            IBasketCalculatorService calculator = new BasketCalculatorService();

            Assert.Equal(3.45m, calculator.CalculateBasketPrice(basket));
        }

        [Fact]
        public void CalculateBasketPrice_BasketHasTwoButterOneBreadAndEightMilk_ReturnsCorrectTotalAfterOffer()
        {
            IBasket basket = new Basket();

            basket.Items.Add(fakeButter);
            basket.Items.Add(fakeButter);
            basket.Items.Add(fakeBread);
            basket.Items.Add(fakeMilk);
            basket.Items.Add(fakeMilk);
            basket.Items.Add(fakeMilk);
            basket.Items.Add(fakeMilk);
            basket.Items.Add(fakeMilk);
            basket.Items.Add(fakeMilk);
            basket.Items.Add(fakeMilk);
            basket.Items.Add(fakeMilk);

            IBasketCalculatorService calculator = new BasketCalculatorService();

            Assert.Equal(9m, calculator.CalculateBasketPrice(basket));
        }

        [Fact]
        public void AddBasket_AddsTheBasketToTheCollection()
        {
            IBasket basket = new Basket();
            basket.Items.Add(fakeButter);

            IBasketCalculatorService calculator = new BasketCalculatorService();

            Assert.Equal(0, calculator.Baskets.Count);

            calculator.AddBasket(basket);

            Assert.Equal(1, calculator.Baskets.Count);
        }

        [Fact]
        public void AddBasket_AddsAnIdToTheBasket()
        {
            IBasket basket = new Basket();
            basket.Items.Add(fakeButter);

            IBasketCalculatorService calculator = new BasketCalculatorService();

            calculator.AddBasket(basket);

            Assert.IsType<Guid>(basket.Id);
        }
    }
}