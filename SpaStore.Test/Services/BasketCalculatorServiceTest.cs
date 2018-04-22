namespace SpaStore.Test.Services
{
    using System;
    using System.Collections.Generic;
    using Models;
    using NSubstitute;
    using SpaStore.Models;
    using SpaStore.Services;
    using Xunit;

    public class BasketCalculatorServiceTest
    {
        private readonly IProductService fakeProductService;
        private readonly Product fakeButter;
        private readonly Product fakeMilk;
        private readonly Product fakeBread;

        public BasketCalculatorServiceTest()
        {
            fakeProductService = Substitute.For<IProductService>();
            fakeProductService.GetProducts().ReturnsForAnyArgs(new List<Product>());

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
        public void CalculateBasketPrice_ItemPriceHasBeenTamperedWith_BasketIsRecertifiedAndPriceCorrected()
        {
            IBasket basket = new Basket();

            Product forgedButter = new Product
            {
                Id = 1,
                Name = "Butter",
                Price = 0.8m
            };
            basket.Items.Add(forgedButter);

            fakeProductService.GetProducts().ReturnsForAnyArgs(new List<Product> { fakeButter });

            IBasketCalculatorService calculator = new BasketCalculatorService(fakeProductService);

            Assert.Equal(0.8m, calculator.CalculateBasketPrice(basket));
        }

        [Fact]
        public void CalculateBasketPrice_BasketIsEmpty_ReturnsZero()
        {
            IBasket basket = new Basket();

            IBasketCalculatorService calculator = new BasketCalculatorService(fakeProductService);

            Assert.Equal(0m, calculator.CalculateBasketPrice(basket));
        }

        [Fact]
        public void CalculateBasketPrice_BasketHasOneOfEachProduct_ReturnsCorrectTotal()
        {
            IBasket basket = new Basket();

            basket.Items.Add(fakeButter);
            basket.Items.Add(fakeMilk);
            basket.Items.Add(fakeBread);

            IBasketCalculatorService calculator = new BasketCalculatorService(fakeProductService);

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

            IBasketCalculatorService calculator = new BasketCalculatorService(fakeProductService);

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

            IBasketCalculatorService calculator = new BasketCalculatorService(fakeProductService);

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

            IBasketCalculatorService calculator = new BasketCalculatorService(fakeProductService);

            Assert.Equal(9m, calculator.CalculateBasketPrice(basket));
        }

        [Fact]
        public void AddBasket_AddsTheBasketToTheCollection()
        {
            IBasket basket = new Basket();
            basket.Items.Add(fakeButter);

            IBasketCalculatorService calculator = new BasketCalculatorService(fakeProductService);

            Assert.Equal(0, calculator.Baskets.Count);

            calculator.AddBasket(basket);

            Assert.Equal(1, calculator.Baskets.Count);
        }

        [Fact]
        public void AddBasket_AddsAnIdToTheBasket()
        {
            IBasket basket = new Basket();
            basket.Items.Add(fakeButter);

            IBasketCalculatorService calculator = new BasketCalculatorService(fakeProductService);

            calculator.AddBasket(basket);

            Assert.IsType<Guid>(basket.Id);
        }
    }
}