using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library
{
    public class ConfigHelper 
    {
        public static decimal GetTaxRate()
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
