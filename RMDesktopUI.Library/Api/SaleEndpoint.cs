using RMDesktopUI.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Api
{
    public class SaleEndpoint : ISaleEndpoint
    {
        private IAPIHelper _apiHelper;
        public SaleEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;

        }
        public async Task PostSale(SaleModel sale)
        {
            using (HttpResponseMessage responce = await _apiHelper.ApiClient.PostAsJsonAsync("/api/Sale", sale))
            {
                if (responce.IsSuccessStatusCode)
                {

                }
                else
                {
                    throw new Exception(responce.ReasonPhrase);
                }
            }
        }

    }
}
