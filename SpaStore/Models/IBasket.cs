namespace SpaStore.Models
{
    using System.Collections.Generic;

    /// <summary> A shopping basket. </summary>
    public interface IBasket
    {
        /// <summary> Items within the basket. </summary>
        IList<IProduct> Items { get; }

        /// <summary> Add an item to the basket. </summary>
        /// <returns> True if the item was added. </returns>
        bool Add();

        /// <summary> Remove an item from the basket. </summary>
        /// <returns> True if it was removed. </returns>
        bool Remove();

        /// <summary> Calculate the price of the basket </summary>
        /// <returns> The total price. </returns>
        decimal Calculate();
    }
}
