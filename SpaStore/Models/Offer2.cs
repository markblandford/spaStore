namespace SpaStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary> Offer 2. </summary>
    public class Offer2 : IOffer
    {
        /// <summary> Constructor. </summary>
        public Offer2()
        {
            Id = 2;
            OfferDescription = "Buy 3 Milk and get the 4th milk for free";
            OfferPrice = 3.45m;

            OfferRules = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(2, 4)
            };

            ProductsInOffer = new List<IProduct>();
        }

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
        public void CheckOfferConditions()
        {
            bool filled = ProductsInOffer.Count(p => p.Id == OfferRules[0].Item1) == OfferRules[0].Item2;

            OfferSatisfied = filled;
        }

        /// <inheritdoc />
        public bool OfferSatisfied { get; private set; }
    }
}