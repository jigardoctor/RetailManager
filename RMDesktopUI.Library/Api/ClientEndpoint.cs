using RMDesktopUI.Library.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Api
{
    public class ClientEndpoint : IClientEndpoint
    {
        private readonly IAPIHelper _apiHelper;

        public ClientEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<ClientModel>> GetAll()
        {
            using (HttpResponseMessage responce = await _apiHelper.ApiClient.GetAsync("/api/Em/Admin/Client"))
            {
                if (responce.IsSuccessStatusCode)
                {
                    var result = await responce.Content.ReadAsAsync<List<ClientModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(responce.ReasonPhrase);
                }
            }
        }
        public async Task AddBranch(ClientModel clientmodel)
        {
            var data = new { };
            using (HttpResponseMessage responce = await _apiHelper.ApiClient.PostAsJsonAsync("/api/Em/Admin/AddClient", clientmodel))
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
        public async Task RemoveBranch(ClientModel clientmodel)
        {
            //var data = new { branchId };
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/Em/Admin/RemoveClient", clientmodel))
            {
                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public async Task EditBranch(ClientModel clientmodel)
        {
            //var data = new { branchId };
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/Em/Admin/EditClient", clientmodel))
            {
                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}

