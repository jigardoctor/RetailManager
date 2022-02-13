using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Helper
{
    public class ConfigHelper : IConfigHelper
    {
        public decimal GetTaxRate()
        {
            string rateText = ConfigurationManager.AppSettings["taxRate"];
            bool IsVisibleTaxRate = Decimal.TryParse(rateText, out decimal output);
            if (IsVisibleTaxRate == false)
            {

            }
            return output;
        }
    }
}
