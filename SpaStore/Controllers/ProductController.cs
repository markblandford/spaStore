namespace SpaStore.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services;

    /// <summary> Product Controller. </summary>
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        /// <summary> Constructor. </summary>
        /// <param name="productService"> injected service. </param>
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary> Get the products. </summary>
        /// <returns> The products. </returns>
        [HttpGet("product")]
        public IList<Product> GetProducts()
        {
            return productService.GetProducts();
        }
    }
}
