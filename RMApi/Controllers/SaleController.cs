﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMDataManager.Library.DataAccess;
using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleController : ControllerBase
    {
        [Authorize(Roles = "Cashier")]
        public void Post(SaleModel sale)
        {
            SaleData data = new SaleData();

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);//RequestContext.Principal.Identity.GetUserId();
            data.SaveSale(sale, userId);

        }
        [Authorize(Roles = "Admin,Manager")]
        [Route("GetSalesReport")]
        [HttpGet]
        public List<SaleReportModel> GetSalesReports()
        {
            //if(RequestContext.Principal.IsInRole("Admin"))
            // {
            //     // do admin roll    
            // }
            // else if (RequestContext.Principal.IsInRole("Manager"))
            // {
            //     //do manager role
            // }
            SaleData data = new SaleData();
            return data.GetSaleReport();
        }
    }
}
