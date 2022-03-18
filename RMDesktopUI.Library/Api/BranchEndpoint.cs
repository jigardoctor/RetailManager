using RMDesktopUI.Library.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Api
{
    public class BranchEndpoint : IBranchEndpoint
    {
        private IAPIHelper _apiHelper;

        public BranchEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task<List<BranchModel>> GetAll()
        {
            using (HttpResponseMessage responce = await _apiHelper.ApiClient.GetAsync("/api/Em"))
            {
                if (responce.IsSuccessStatusCode)
                {
                    var result = await responce.Content.ReadAsAsync<List<BranchModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(responce.ReasonPhrase);
                }
            }
        }
        public async Task AddBranch(BranchModel brancmodel)
        {
            var data = new { };
            using (HttpResponseMessage responce = await _apiHelper.ApiClient.PostAsJsonAsync("/api/Em/Admin/Add", brancmodel))
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
        public async Task RemoveBranch(BranchModel brancmodel)
        {
            //var data = new { branchId };
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/Em/Admin/Remove", brancmodel))
            {
                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public async Task EditBranch(BranchModel brancmodel)
        {
            //var data = new { branchId };
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/Em/Admin/Edit", brancmodel))
            {
                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
