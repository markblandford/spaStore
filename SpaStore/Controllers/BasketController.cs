namespace SpaStore.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services;

    /// <summary> Basket controller. </summary>
    public class BasketController : Controller
    {
        private IBasketCalculatorService basketCalculator;

        /// <summary> Constructor. </summary>
        public BasketController()
        {
            basketCalculator = new BasketCalculatorService();
        }

        /// <summary> Add a basket. </summary>
        /// <param name="basket"> The basket to add for pricing. </param>
        /// <returns> The ID of the basket. </returns>
        [HttpPost("basket")]
        public Guid AddBasket([FromBody] IBasket basket)
        {
            throw new NotImplementedException();
        }

        /// <summary> Get the price of a basket. </summary>
        /// <param name="basketId"> The Id of the basket to price. </param>
        /// <returns> The price. </returns>
        /// <response code="404">basket not found</response>
        [HttpGet("basket/{basketId}")]
        public decimal GetBasketPrice([FromRoute] Guid basketId)
        {
            throw new NotImplementedException();
        }
    }
}