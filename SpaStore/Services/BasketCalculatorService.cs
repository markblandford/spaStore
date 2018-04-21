namespace SpaStore.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class BasketCalculatorService : IBasketCalculatorService
    {
        /// <inheritdoc />
        public decimal CalculateBasketPrice(IBasket basket)
        {
            throw new NotImplementedException();
        }
    }
}
