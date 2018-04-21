namespace SpaStore.Models
{
    using System.Collections.Generic;

    /// <summary> The interface for an offer. </summary>
    public interface IOffer
    {
        /// <summary> Unique Id of the offer. </summary>
        int Id { get; }

        /// <summary> Items added to the offer. </summary>
        IList<IProduct> ProductsInOffer { get; set; }

        /// <summary> The description of the offer. </summary>
        string OfferDescription { get; }

        /// <summary> The price for the offer. </summary>
        decimal OfferPrice { get; }

        /// <summary> Whether the rule of the offer has been met. </summary>
        /// <returns> True if the terms of the offer has been met. </returns>
        bool OfferSatisfied();
    }
}