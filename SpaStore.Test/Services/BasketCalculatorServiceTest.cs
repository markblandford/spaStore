namespace SpaStore.Test.Services
{
    using Models;
    using SpaStore.Services;
    using Xunit;

    public class BasketCalculatorServiceTest
    {
        private IProduct fakeButter;
        private IProduct fakeMilk;
        private IProduct fakeBread;

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

            BasketCalculatorService calculator = new BasketCalculatorService();

            Assert.Equal(0m, calculator.CalculateBasketPrice(basket));
        }

        [Fact]
        public void CalculateBasketPrice_BasketHasOneOfEachProduct_ReturnsCorrectTotal()
        {
            IBasket basket = new Basket();

            basket.Items.Add(fakeButter);
            basket.Items.Add(fakeMilk);
            basket.Items.Add(fakeBread);

            BasketCalculatorService calculator = new BasketCalculatorService();

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

            BasketCalculatorService calculator = new BasketCalculatorService();

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

            BasketCalculatorService calculator = new BasketCalculatorService();

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

            BasketCalculatorService calculator = new BasketCalculatorService();

            Assert.Equal(9m, calculator.CalculateBasketPrice(basket));
        }
    }
}