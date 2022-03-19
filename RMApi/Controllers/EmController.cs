using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMDataManager.Library.DataAccess;
using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmController : ControllerBase
    {
        private readonly IBranchData _Branch;
        private readonly IClientData _client;

        public EmController(IBranchData branch,IClientData client)
        {
            _Branch = branch;
           _client = client;
        }
        [HttpGet]
        [Route("Admin/Client")]
        public List<ClientModel> GetClient()
        {
           return _client.Getclient();
        }
        [HttpPost]
        [Route("Admin/AddClient")]
        public void PostClient(ClientModel client)
        {

            _client.Addclient(client);

        }
        [HttpPost]
        [Route("Admin/RemoveClient")]
        public void DeleteClient(ClientModel client)
        {
            _client.Removeclient(client);
        }
        [HttpPost]
        [Route("Admin/EditClient")]
        public void EditClient(ClientModel client)
        {
            _client.Editclient(client);
        }





        [HttpGet]
        [Route("Admin/Branch")]
        public List<BranchModel> Get()
        {
            //ProductData data = new ProductData(_config);
            return _Branch.GetBranch();
        }
        [HttpPost]
        [Route("Admin/AddBranch")]
        public void Post(BranchModel branch)
        {

            _Branch.AddBranch( branch);

        }
        [HttpPost]
        [Route("Admin/RemoveBranch")]
        public void Delete(BranchModel branch)
        {
            _Branch.RemoveBranch(branch);
        }
        [HttpPost]
        [Route("Admin/EditBranch")]
        public void Edit(BranchModel branch)
        {
            _Branch.EditBranch(branch);
        }
    }
}
