namespace SpaStore.Test.Models
{
    using SpaStore.Models;
    using Xunit;

    public class Offer2Test
    {
        [Fact]
        public void Constructor_SetsTheDefaultValues()
        {
            IOffer cut = new Offer2();

            Assert.Equal("Buy 3 Milk and get the 4th milk for free", cut.OfferDescription);
            Assert.Equal(3.45m, cut.OfferPrice);
            Assert.NotNull(cut.OfferRules);
            Assert.NotNull(cut.ProductsInOffer);
        }
    }
}
