namespace SpaStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary> Offer 1. </summary>
    public class Offer1 : IOffer
    {
        /// <summary> Constructor. </summary>
        public Offer1()
        {
            Id = 1;
            OfferDescription = "Buy 2 Butter and get a Bread at 50% off";
            OfferPrice = 2.1m;

            OfferRules = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(3, 1)
            };

            ProductsInOffer = new List<Product>();
        }

        /// <inheritdoc />
        public int Id { get; }

        /// <inheritdoc />
        public IList<Tuple<int, int>> OfferRules { get; }

        /// <inheritdoc />
        public IList<Product> ProductsInOffer { get; set; }

        /// <inheritdoc />
        public string OfferDescription { get; }

        /// <inheritdoc />
        public decimal OfferPrice { get; }

        /// <inheritdoc />
        public void CheckOfferConditions()
        {
            bool filled = ProductsInOffer.Count(p => p.Id == OfferRules[0].Item1) == OfferRules[0].Item2
                   && ProductsInOffer.Count(p => p.Id == OfferRules[1].Item1) == OfferRules[1].Item2;

            OfferSatisfied = filled;
        }

        /// <inheritdoc />
        public bool OfferSatisfied { get; private set; }
    }
}