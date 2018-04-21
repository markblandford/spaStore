namespace SpaStore.Services
{
    using System.Collections.Generic;
    using Models;

    /// <summary> Service to calculate a basket. </summary>
    public interface IBasketCalculatorService
    {
        /// <summary> Calculate the total value of a basket. </summary>
        /// <param name="basket"> The basket to calculate the total for. </param>
        /// <returns> The total price. </returns>
        decimal CalculateBasketPrice(IBasket basket);
    }
}
