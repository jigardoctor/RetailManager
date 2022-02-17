 using RMDataManager.Library.Internal.DataAccess;
using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library.DataAccess
{
    public class SaleData
    {
        //private readonly IProductData _productData;
        // private readonly ISqlDataAccess _sql;
        //private readonly IConfiguration _config;

        //public SaleData(IProductData productData, ISqlDataAccess sql, IConfiguration config)
        //{
        //    _productData = productData;
        //    _sql = sql;
        //    _config = config;
        //}

        public void SaveSale(SaleModel saleInfo, string cashierId)
        {
            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();
            ProductData products = new ProductData();
            var taxRate = ConfigHelper.GetTaxRate() / 100;
            foreach (var item in saleInfo.SaleDetails)
            {
                var detail = new SaleDetailDBModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };
                var productInfo = products.GetProductByid(detail.ProductId);
                if (productInfo == null)
                {
                    throw new Exception($"The Product Id of {detail.ProductId} could not be found in database.");

                }
                detail.PurchasePrice = (productInfo.RetailPrice * detail.Quantity);
                if (productInfo.IsTaxable)
                {
                    detail.Tax = (detail.PurchasePrice * taxRate);
                }
                details.Add(detail);
            }
            SaleDBModel sale = new SaleDBModel
            {
                SubTotal = details.Sum(x => x.PurchasePrice),
                Tax = details.Sum(x => x.Tax),
                CashierId = cashierId
            };
            sale.Total = sale.SubTotal + sale.Tax;

            using (SqlDataAccess sql = new SqlDataAccess())
            {

                try
                {
                    sql.StartTransaction("RMData");
                    sql.SaveDataInTransaction<SaleDBModel>("dbo.spSale_Insert", sale);
                    sale.Id = sql.LoadDataInTransaction<int, dynamic>("spSale_Lookup", new { sale.CashierId, sale.SaleDate }).FirstOrDefault();
                    foreach (var item in details)
                    {
                        item.SaleId = sale.Id;

                        // Save the sale details models
                        sql.SaveDataInTransaction("dbo.spSaleDetail_Insert", item);
                    }
                    sql.CommitTransaction();
                }
                catch (Exception ex)
                {

                    sql.RollbackTransaction();
                    throw;
                }
            }


            //try
            //{
            //    _sql.StartTransaction("TRMData");
            //    //Save the model
            //    _sql.SaveDataInTransaction<SaleDBModel>("dbo.spSale_Insert", sale);

            //    // Get the Id from the sale model
            //    sale.Id = _sql.LoadDataInTransaction<int, dynamic>("dbo.spSale_Lookup", new { CashierId = sale.CashierId, SaleDate = sale.SaleDate }).FirstOrDefault();

            //    // Finish filling in the sale details models
            //    foreach (var item in details)
            //    {
            //        item.SaleId = sale.Id;

            //        // Save the sale details models
            //        _sql.SaveDataInTransaction("dbo.spSaleDetail_Insert", item);
            //    }

            //    //Can explicitly call but it will implicitly close after using statment finished.
            //    _sql.CommitTransaction();
            //}
            //catch
            //{
            //    _sql.RollbackTransaction();
            //    throw;
            //}
        } 
    }
}
