using ApiAthanasia.Models.Request;
using ApiAthanasia.Models.Response;
using ApiAthanasia.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAthanasia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserClientController : ControllerBase
    {
        private IUserClientService _userClientService;
        public UserClientController(IUserClientService userClientService)
        {
            _userClientService = userClientService;
        }

        [HttpPost("login")]
        public IActionResult Authentification([FromBody]AuthRequest model)
        {
            Response R = new Response();
            var userResponse = _userClientService.Auth(model);

            if (userResponse == null)
            {
                R.Message = "Invalid Email or password";
                return BadRequest(R);
            }
            R.Success = true;
            R.Message = "Succesful login";
            R.Data = userResponse;

            return Ok(R);
        }

    }
}
