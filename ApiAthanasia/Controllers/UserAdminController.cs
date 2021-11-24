using ApiAthanasia.Models.Request;
using ApiAthanasia.Models.Response;
using ApiAthanasia.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAthanasia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAdminController : ControllerBase
    {
        private IUserAdminService _userAdminService;
        public UserAdminController(IUserAdminService userAdminService)
        {
            _userAdminService = userAdminService;
        }
        [HttpPost("login")]
        public IActionResult Authentification([FromBody] AuthRequest model)
        {
            Response R = new Response();
            var userResponse = _userAdminService.Auth(model);

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
