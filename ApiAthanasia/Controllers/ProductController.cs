using ApiAthanasia.Models;
using ApiAthanasia.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAthanasia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "admin, client")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Response R = new Response();
            try
            {
                using (AthanasiaContext DB = new AthanasiaContext())
                {
                    var productList = DB.Products.OrderByDescending(b => b.Id)
                        .ToList();
                    R.Success = true;
                    R.Message = "ProductsGet succesful";
                    R.Data = productList;
                }
            }
            catch (Exception ex)
            {
                R.Message = ex.Message;
            }
            return Ok(R);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetSpecifiedProduct(int id)
        {
            Response R = new Response();
            try
            {
                using (AthanasiaContext DB = new AthanasiaContext())
                {
                    var product = DB.Products.Where(product => product.Id == id).ToList();
                    R.Success = true;
                    R.Message = "GetSpecifiedProduct Succesful";
                    R.Data = product;
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
