using ApiAthanasia.Models;
using ApiAthanasia.Models.Request;
using ApiAthanasia.Models.Response;
using ApiAthanasia.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAthanasia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Instance
        private IProductService _productService;
        public ProductController(IProductService service)
        {
            this._productService = service;
        }

        #endregion

        #region GetAllProducts
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
        #endregion

        #region GetSpecifiedProductByID
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
        #endregion

        #region AddNewProduct
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddProduct(ProductRequest request)
        {
            Response R = new Response();
            R = this._productService.AddProduct(request);
            return Ok(R);
        }
        #endregion

        #region UpdateProduct
        [HttpPost("{id:int}")]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateProduct(ProductRequest request, int id)
        {
            Response R = new Response();
            R = this._productService.UpdateProduct(request, id);
            return Ok(R);
        }
        #endregion

        #region DeleteProduct
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteProduct(int id)
        {
            Response R = new Response();
            R = this._productService.DeleteProduct(id);
            return Ok(R);
        }
        #endregion
    }
}