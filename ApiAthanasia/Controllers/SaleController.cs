using ApiAthanasia.Models;
using ApiAthanasia.Models.Request;
using ApiAthanasia.Models.Response;
using ApiAthanasia.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAthanasia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private ISaleService _sale;
        public SaleController(ISaleService sale)
        {
            this._sale = sale;
        }

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
        [HttpPost]
        public IActionResult Add(SaleRequest saleRequested)
        {
            Response R = new Response();
            try
            {
                this._sale.Add(saleRequested);
                R.Success = true;
            }
            catch (Exception ex)
            {
                R.Message = ex.Message;  
            }
            return Ok(R);
        }
    }
}
