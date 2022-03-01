using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
       // private readonly IConfiguration _config;
        private readonly ISaleData _saleData;

        public SaleController(ISaleData saleData)
        {
         //   _config = config;
            _saleData = saleData;
        }
        [Authorize(Roles = "Admin, Manager,Cashier")]
        [HttpPost ]
        public void Post(SaleModel sale)
        {
           // SaleData data = new SaleData(_config);

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);//RequestContext.Principal.Identity.GetUserId();
            _saleData.SaveSale(sale, userId);

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
           // SaleData data = new SaleData(_config);
            return _saleData.GetSaleReport();
        }
    }
}
