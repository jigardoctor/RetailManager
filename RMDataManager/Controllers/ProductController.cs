using RMDataManager.Library.DataAccess;
using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RMDataManager.Controllers
{
    public class ProductController : ApiController
    {
      //  [Authorize]
        public List<ProductModel> Get()
        {
            ProductData data = new ProductData();
          return  data.GetProducts();
        }

        //[Route("api/[controller]")]
        //[ApiController]
        //[Authorize(Roles = "Cashier")]
        //public class ProductController : ControllerBase
        //{
        //    private readonly IProductData _productData;

        //    public ProductController(IProductData productData)
        //    {
        //        _productData = productData;
        //    }

        //    GET: api/Product
        //   [HttpGet]
        //    public List<ProductModel> Get()
        //    {
        //        return _productData.GetAllProduct();
        //    }
        //}
    }
}
