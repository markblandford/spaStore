namespace SpaStore.Test.Models
{
    using SpaStore.Models;
    using Xunit;

    public class Offer1Test
    {
        [Fact]
        public void Constructor_SetsTheDefaultValues()
        {
            IOffer cut = new Offer1();

            Assert.Equal("Buy 2 Butter and get a Bread at 50% off", cut.OfferDescription);
            Assert.Equal(2.1m, cut.OfferPrice);
            Assert.NotNull(cut.OfferRules);
            Assert.NotNull(cut.ProductsInOffer);
        }
    }
}
