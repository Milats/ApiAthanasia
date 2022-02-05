using ApiAthanasia.Models.Request;
using ApiAthanasia.Models.Response;
using ApiAthanasia.Services.ShoppingCartServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAthanasia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "client, admin")]
    public class ShoppingCartController : ControllerBase
    {
        private IShoppingCartService _cart;
        public ShoppingCartController(IShoppingCartService cart)
        {
            this._cart = cart;
        }


        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Response R = new Response();
            R = this._cart.GetCartByIDUserClient(id);
            return Ok(R);
        }
        [HttpPost]
        public IActionResult Add(ShoppingCartRequest request)
        {
            Response R = new Response();
            try
            {
                R = this._cart.Add(request);
            } catch(Exception ex)
            {
                R.Message = ex.Message;
            }
            return Ok(R);
        }

        [HttpDelete("{user:int}")]
        public IActionResult Delete(int user)
        {
            Response R = new Response();
            R = this._cart.DeleteCartByUserID(user);
            return Ok(R);
        }
    }
}