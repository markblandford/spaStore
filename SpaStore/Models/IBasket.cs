namespace SpaStore.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary> A shopping basket. </summary>
    public interface IBasket
    {
        /// <summary> Basket Id. </summary>
        Guid? Id { get; set; }

        /// <summary> Items within the basket. </summary>
        IList<Product> Items { get; }
    }
}
