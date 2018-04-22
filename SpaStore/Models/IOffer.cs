namespace SpaStore.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary> The interface for an offer. </summary>
    public interface IOffer
    {
        /// <summary> Unique Id of the offer. </summary>
        int Id { get; }

        /// <summary> The rules of the offer. </summary>
        IList<Tuple<int, int>> OfferRules { get; }

        /// <summary> Items added to the offer. </summary>
        IList<Product> ProductsInOffer { get; set; }

        /// <summary> The description of the offer. </summary>
        string OfferDescription { get; }

        /// <summary> The price for the offer. </summary>
        decimal OfferPrice { get; }

        /// <summary> Check whether the rules for the order have been met, setting whether it has been satisfied. </summary>
        void CheckOfferConditions();

        /// <summary> Whether the rule of the offer has been met. </summary>
        bool OfferSatisfied { get; }
    }
}