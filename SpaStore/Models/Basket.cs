namespace SpaStore.Models
{
    using System.Collections.Generic;

    public class Basket : IBasket
    {
        public Basket()
        {
            Items = new List<IProduct>();
        }

        /// <inheritdoc />
        public IList<IProduct> Items { get; }

        /// <inheritdoc />
        public bool Add()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public bool Remove()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public decimal Calculate()
        {
            throw new System.NotImplementedException();
        }
    }
}
