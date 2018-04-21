namespace SpaStore.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary> Basket. </summary>
    public class Basket : IBasket
    {
        /// <summary> Constructor. </summary>
        public Basket()
        {
            Items = new List<IProduct>();
        }

        /// <inheritdoc />
        public Guid Id { get; set; }

        /// <inheritdoc />
        public IList<IProduct> Items { get; }
    }
}
