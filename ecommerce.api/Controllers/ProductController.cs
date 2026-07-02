using ecommerce.app.common;
using ecommerce.app.contracts;
using ecommerce.app.DTOS.products;
using ecommerce.app.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.api.Controllers
{

    public class ProductController(IProductService service) : APIbasecontoller
    {
        #region  getaall product


        [HttpGet]
        [ProducesResponseType(typeof(ProductsDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<Pagginationresult<ProductsDTO>>> GetAllProducts([FromQuery]Productquerryprams productquerryprams,CancellationToken ct)
        {
            var products = await service.GetAllProductAsync(productquerryprams, ct);

            return Ok(products);
        }

        #endregion

        #region  get product
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ProductsDTO), StatusCodes.Status200OK)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductsDTO>> getproduct(int id, CancellationToken ct)
        {


            var product = await service.GetProductAsync(id, ct);
            return ToActionResult(product);
        }

        #endregion



        #region get all brands
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<BrandDTO>>> GetAllBrand(CancellationToken ct)=>ToActionResult(await service.GetAllBrandAsync(ct));
        #endregion


        #region get all type
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<TypeDTO>>> GetallType(CancellationToken ct) => ToActionResult(await service.GetAllTypeAsync(ct));
        #endregion
    }
}
