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
    [Authorize]
    public class EmController : ControllerBase
    {
        private readonly IBranchData _Branch;
        private readonly IClientData _client;

        public EmController(IBranchData branch,IClientData client)
        {
            _Branch = branch;
           _client = client;
        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        [Route("Admin/Client")]
        public List<ClientModel> GetClient()
        {
           return _client.Getclient();
        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        [Route("Admin/AddClient")]
        public void PostClient(ClientModel client)
        {

            _client.Addclient(client);

        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        [Route("Admin/RemoveClient")]
        public void DeleteClient(ClientModel client)
        {
            _client.Removeclient(client);
        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        [Route("Admin/EditClient")]
        public void EditClient(ClientModel client)
        {
            _client.Editclient(client);
        }




        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        [Route("Admin/Branch")]
        public List<BranchModel> Get()
        {
            //ProductData data = new ProductData(_config);
            return _Branch.GetBranch();
        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        [Route("Admin/AddBranch")]
        public void Post(BranchModel branch)
        {

            _Branch.AddBranch( branch);

        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        [Route("Admin/RemoveBranch")]
        public void Delete(BranchModel branch)
        {
            _Branch.RemoveBranch(branch);
        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        [Route("Admin/EditBranch")]
        public void Edit(BranchModel branch)
        {
            _Branch.EditBranch(branch);
        }
    }
}
