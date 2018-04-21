namespace SpaStore.Models
{
    public class Product : IProduct
    {
        /// <inheritdoc />
        public int Id { get; set; }

        /// <inheritdoc />
        public string Name { get; set; }

        /// <inheritdoc />
        public decimal Price { get; set; }
    }
}
