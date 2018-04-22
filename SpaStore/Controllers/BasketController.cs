namespace SpaStore.Controllers
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services;
    using Utils;

    /// <summary> Basket controller. </summary>
    public class BasketController : Controller
    {
        private readonly IBasketCalculatorService basketCalculator;

        /// <summary> Constructor. </summary>
        /// <param name="basketCalculatorService"> injected service. </param>
        public BasketController(IBasketCalculatorService basketCalculatorService)
        {
            basketCalculator = basketCalculatorService;
        }

        /// <summary> Add a basket. </summary>
        /// <param name="basket"> The basket to add for pricing. </param>
        /// <returns> The basket with an Id added or updated. </returns>
        [HttpPost("basket")]
        public IBasket AddBasket([FromBody] Basket basket)
        {
            if (basket == null)
            {
                basket = new Basket();
            }

            basketCalculator.AddBasket(basket);

            return basket;
        }

        /// <summary> Get the price of a basket. </summary>
        /// <param name="basketId"> The Id of the basket to price. </param>
        /// <returns> The price. </returns>
        /// <response code="404">basket not found</response>
        [HttpGet("basket/{basketId}")]
        public decimal GetBasketPrice([FromRoute] Guid basketId)
        {
            IBasket basket = basketCalculator.Baskets.SingleOrDefault(b => b.Id == basketId);

            if (basket == null)
            {
                Respond.NotFound();
            }

            return basketCalculator.CalculateBasketPrice(basket);
        }
    }
}