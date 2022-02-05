﻿using ApiAthanasia.Models;
using ApiAthanasia.Models.Exceptions;
using ApiAthanasia.Models.Request;
using ApiAthanasia.Models.Response;
using ApiAthanasia.Services;
using ApiAthanasia.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiAthanasia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        #region Instance
        private ISaleService _sale;
        public SaleController(ISaleService sale)
        {
            this._sale = sale;
        }
        #endregion

        #region GetAllSales
        [Authorize(Roles = "admin")]
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
        #endregion

        #region GetSalesByUserID

        [HttpGet("{user:int}")]
        [Authorize(Roles = "admin, client")]
        public IActionResult Get(int user)
        {
            Response R = new Response();
            try
            {
                using (AthanasiaContext DB = new AthanasiaContext())
                {
                    var saleList = DB.Sales.Where(sale => sale.IduserClient == user).OrderByDescending(b => b.Date)
                        .ToList();
                    R.Success = true;
                    R.Message = "SaleSpecified Get Succesful";
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

        #region AddSale
        [Authorize(Roles = "client")]
        [HttpPost]
        public IActionResult Add(SaleRequest saleRequested)
        {
            Response R = new Response();
            ProductService pS = new ProductService();
            try
            {
                R = pS.CheckAvailableProductStock(saleRequested);
                if (R.Success)
                {
                    R = this._sale.Add(saleRequested);
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