namespace SpaStore.Services
{
    using System.Collections.Generic;
    using Models;

    /// <summary> Interface to get all the available products. </summary>
    public interface IProductService
    {
        /// <summary> Get the Products. </summary>
        /// <returns> the product list. </returns>
        IList<Product> GetProducts();
    }
}