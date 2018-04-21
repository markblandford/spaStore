namespace SpaStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary> Offer 1. </summary>
    public class Offer1 : IOffer
    {
        /// <inheritdoc />
        public int Id { get; }

        /// <inheritdoc />
        public IList<Tuple<int, int>> OfferRules { get; }

        /// <inheritdoc />
        public IList<IProduct> ProductsInOffer { get; set; }

        /// <inheritdoc />
        public string OfferDescription { get; }

        /// <inheritdoc />
        public decimal OfferPrice { get; }

        /// <inheritdoc />
        public bool OfferSatisfied()
        {
            throw new NotImplementedException();
        }
    }
}
