using RMDataManager.Library.Models;
using System.Collections.Generic;

namespace RMDataManager.Library.DataAccess
{
    public interface IProductData
    {
        ProductModel GetProductByid(int productId);
        List<ProductModel> GetProducts();
    }
}