using RMDesktopUI.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Api
{
    public class ProductEndpoint : IProductEndpoint
    {
        private IAPIHelper _apiHelper;
        public ProductEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;

        }
        public async Task<List<ProductModel>> GetAll()
        {
            using (HttpResponseMessage responce = await _apiHelper.ApiClient.GetAsync("/api/Product"))
            {
                if (responce.IsSuccessStatusCode)
                {
                    var result = await responce.Content.ReadAsAsync<List<ProductModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(responce.ReasonPhrase);
                }



            }
        }
    }
}
