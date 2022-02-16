using RMDataManager.Library.Models;

namespace RMDataManager.Library.DataAccess
{
    public interface ISaleData
    {
        void SaveSale(SaleModel saleInfo, string cashierId);
    }
}