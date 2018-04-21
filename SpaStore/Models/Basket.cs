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
        public IList<IProduct> Items { get; }

        /// <inheritdoc />
        public bool Add()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool Remove()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public decimal Calculate()
        {
            throw new NotImplementedException();
        }
    }
}
