namespace SpaStore.Services
{
    using System;
    using System.Collections.Generic;
    using Models;

    /// <summary> Service to calculate a basket. </summary>
    public interface IBasketCalculatorService
    {
        /// <summary> Basket population. </summary>
        IList<IBasket> Baskets { get; set; }

        /// <summary> Add a basket. </summary>
        /// <param name="basket"> The basket to add. </param>
        /// <returns> The Id of the basket. </returns>
        Guid AddBasket(IBasket basket);

        /// <summary> Calculate the total value of a basket. </summary>
        /// <param name="basket"> The basket to calculate the total for. </param>
        /// <returns> The total price. </returns>
        decimal CalculateBasketPrice(IBasket basket);
    }
}
