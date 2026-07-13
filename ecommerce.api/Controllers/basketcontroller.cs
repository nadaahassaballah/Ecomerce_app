using ecommerce.app.contracts;
using ecommerce.app.DTOS.basket;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.api.Controllers
{
    
    public class Basketcontroller(IBasketService basketService) : APIbasecontoller
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BasketDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BasketDTO>> GetBasket(string id, CancellationToken ct)
        {
            var basket = await basketService.GetBasketAsync(id, ct);
            return ToActionResult(basket);
        }
        [HttpPost]
        public async Task<ActionResult<BasketDTO>> CreatOrUpdate(BasketDTO basketDTO, CancellationToken ct)
        {
            var saved = await basketService.CreateOrUpdateBasketAsync(basketDTO, ct);
            return ToActionResult(saved);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteBasket(string id, CancellationToken ct)
        {
            var result = await basketService.DeleteBasketAsync(id, ct);
            return ToActionResult(result);
        }

    }
}
