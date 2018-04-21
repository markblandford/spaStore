namespace SpaStore.Models
{
    /// <summary> A product. </summary>
    public interface IProduct
    {
        /// <summary> Gets or sets the product ID. </summary>
        int Id { get; set; }

        /// <summary> Gets or sets the name of the product. </summary>
        string Name { get; set; }

        /// <summary> Gets or sets the price. </summary>
        decimal Price { get; set; }
    }
}
