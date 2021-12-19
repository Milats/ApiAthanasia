using ApiAthanasia.Models;
using ApiAthanasia.Models.Response;
using ApiAthanasia.Services.ClientsServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAthanasia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "admin")]
    public class ClientsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Response R = new Response();
            try
            {
                using (AthanasiaContext DB = new AthanasiaContext())
                {
                    var productList = DB.UserClients.OrderByDescending(b => b.Id)
                           .ToList();
                    R = ClientsService.EmptyPasswords(productList);
                    R.Success = true;
                    R.Message = "ClientsGetSucessful";
                }
            }
            catch (Exception ex)
            {
                R.Message = ex.Message;
            }
            return Ok(R);
        }
    }
}
