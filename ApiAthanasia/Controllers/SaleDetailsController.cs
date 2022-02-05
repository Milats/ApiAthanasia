using ApiAthanasia.Models;
using ApiAthanasia.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAthanasia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleDetailsController : ControllerBase
    {
        #region GetDetailsBySaleID
        [HttpGet("{id:int}")]
        [Authorize(Roles = "admin, client")]
        public IActionResult Get(int id)
        {
            Response R = new Response();
            try
            {
                using (AthanasiaContext DB = new AthanasiaContext())
                {
                    var saleList = DB.SaleDetails.Where(detail=> detail.Idsale == id)
                        .ToList();
                    R.Success = true;
                    R.Message = "SaleSpecifiedDetailsGet Succesful";
                    R.Data = saleList;
                }
            }
            catch (Exception ex)
            {
                R.Message = ex.Message;
            }
            return Ok(R);
        }
        #endregion
    }
}
