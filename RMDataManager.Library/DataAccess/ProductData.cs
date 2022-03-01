using Microsoft.Extensions.Configuration;
using RMDataManager.Library.Internal.DataAccess;
using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library.DataAccess
{
    public class ProductData : IProductData
    {
       // private readonly IConfiguration _config;
        private readonly ISqlDataAccess _sqlDataAccess;

        public ProductData( ISqlDataAccess sqlDataAccess)
        {
           // _config = config;
            _sqlDataAccess = sqlDataAccess;
        }
        public List<ProductModel> GetProducts()
        {
           // SqlDataAccess sql = new SqlDataAccess(_config);
            var output = _sqlDataAccess.LoadData<ProductModel, dynamic>("dbo.spProduct_GetAll", new { }, "RMData");
            return output;

        }
        public ProductModel GetProductByid(int productId)
        {
            //SqlDataAccess sql = new SqlDataAccess(_config);
            var output = _sqlDataAccess.LoadData<ProductModel, dynamic>("dbo.spProduct_GetById", new { Id = productId }, "RMData").FirstOrDefault();
            return output;

        }

    }
}
