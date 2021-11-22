using ApiAthanasia.Models;
using ApiAthanasia.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAthanasia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Response R = new Response();
            try
            {
                using (AthanasiaContext DB = new AthanasiaContext())
                {
                    var saleList = DB.Sales.OrderByDescending(b => b.Date)
                        .ToList();
                    R.Success = true;
                    R.Message = "SaleGet Succesful";
                    R.Data = saleList;
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
