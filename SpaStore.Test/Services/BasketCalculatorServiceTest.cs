namespace SpaStore.Test.Services
{
    using System;
    using Models;
    using SpaStore.Services;
    using Xunit;

    public class BasketCalculatorServiceTest
    {
        private BasketCalculatorService calculator;
        private IProduct fakeButter;
        private IProduct fakeMilk;
        private IProduct fakeBread;

        public BasketCalculatorServiceTest()
        {
            calculator = new BasketCalculatorService();

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

            Assert.Equal(0m, calculator.CalculateBasketPrice(basket));
        }

        [Fact]
        public void CalculateBasketPrice_BasketHasOneOfEachProduct_ReturnsCorrectTotal()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void CalculateBasketPrice_BasketHasTwoButterAndTwoBread_ReturnsCorrectTotalAfterOffer()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void CalculateBasketPrice_BasketHasFourMilk_ReturnsCorrectTotalAfterOffer()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void CalculateBasketPrice_BasketHasTwoButterOneBreadAndEightMilk_ReturnsCorrectTotalAfterOffer()
        {
            throw new NotImplementedException();
        }
    }
