﻿namespace SpaStore.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    /// <summary> The service to calculate the value of a basket of products. </summary>
    public class BasketCalculatorService : IBasketCalculatorService
    {
        private readonly IProductService productService;

        /// <summary> Constructor. </summary>
        /// <param name="productService"> Product service. </param>
        public BasketCalculatorService(IProductService productService)
        {
            this.productService = productService;
            Baskets = new List<IBasket>();
        }

        /// <inheritdoc />
        public IList<IBasket> Baskets { get; set; }

        /// <inheritdoc />
        public IBasket AddBasket(IBasket basket)
        {
            basket.Id = Guid.NewGuid();

            CertifyBasketItems(basket);
            Baskets.Add(basket);

            return basket;
        }

        private void CertifyBasketItems(IBasket basket)
        {
            IList<Product> availableProducts = productService.GetProducts();

            foreach (Product basketItem in basket.Items)
            {
                Product found = availableProducts.FirstOrDefault(p => p.Id == basketItem.Id);
                basketItem.Name = found?.Name ?? "NOT FOUND";
                basketItem.Price = found?.Price ?? 0;
            }
        }

        /// <inheritdoc />
        public decimal CalculateBasketPrice(IBasket basket)
        {
            IList<IOffer> offerList = new List<IOffer>();

            foreach (var basketItem in basket.Items)
            {
                // offer 1 Buy 2 Butter and get a Bread at 50% off
                if (basketItem.Id == 1 || basketItem.Id == 3)
                {
                    ApplyOffer(basketItem, offerList, 1);
                }
                // offer 2 Buy 3 Milk and get the 4th milk for free
                else if (basketItem.Id == 2)
                {
                    ApplyOffer(basketItem, offerList, 2);
                }
            }

            foreach (var offer in offerList)
            {
                offer.CheckOfferConditions();
            }

            Rebalance(basket, offerList);

            decimal fullPrices = basket.Items.Sum(i => i.Price);

            decimal offerPrices = offerList.Sum(l => l.OfferPrice);

            return fullPrices + offerPrices;
        }

        private void ApplyOffer(Product item, IList<IOffer> offers, int offerId)
        {
            IOffer openOffer = offers.FirstOrDefault(o => o.Id == offerId && !o.OfferSatisfied);

            if (openOffer == null)
            {
                if (offerId == 1)
                {
                    openOffer = new Offer1();
                }
                else
                {
                    openOffer = new Offer2();
                }

                openOffer.ProductsInOffer.Add(item);
                openOffer.CheckOfferConditions();
                offers.Add(openOffer);
            }
            else
            {
                openOffer.ProductsInOffer.Add(item);
                openOffer.CheckOfferConditions();
            }
        }

        private void Rebalance(IBasket basket, IList<IOffer> offers)
        {
            RemoveUnfilledOffers(offers);

            RemoveInitialOrdersWithOffersApplied(basket, offers);
        }

        private void RemoveUnfilledOffers(IList<IOffer> offers)
        {
            IList<IOffer> offersToRemove = new List<IOffer>();

            foreach (var offer in offers.Where(o => !o.OfferSatisfied))
            {
                offersToRemove.Add(offer);
            }

            foreach (var offer in offersToRemove)
            {
                offers.Remove(offer);
            }
        }

        private void RemoveInitialOrdersWithOffersApplied(IBasket basket, IList<IOffer> offers)
        {
            IList<Product> productsToRemove = new List<Product>();

            foreach (var offer in offers.Where(o => o.OfferSatisfied))
            {
                productsToRemove = productsToRemove.Concat(offer.ProductsInOffer).ToList();
            }

            foreach (var item in productsToRemove)
            {
                basket.Items.Remove(item);
            }
        }
    }
}
