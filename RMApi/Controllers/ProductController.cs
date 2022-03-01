using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RMDataManager.Library.DataAccess;
using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProductController : ControllerBase
    {
       // private readonly IConfiguration _config;
        private readonly IProductData _productData;

        public ProductController( IProductData productData)
        {
          // _config = config;
           _productData = productData;
        }
        [HttpGet]
        public List<ProductModel> Get()
        {
            //ProductData data = new ProductData(_config);
            return _productData.GetProducts();
        }
    }
}
