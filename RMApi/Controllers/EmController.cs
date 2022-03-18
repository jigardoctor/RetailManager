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

        public EmController(IBranchData branch)
        {
            _Branch = branch;
        }

        [HttpGet]
        public List<BranchModel> Get()
        {
            //ProductData data = new ProductData(_config);
            return _Branch.GetBranch();
        }
        [HttpPost]
        [Route("Admin/Add")]
        public void Post(BranchModel branch)
        {

            _Branch.AddBranch( branch);

        }
        [HttpPost]
        [Route("Admin/Remove")]
        public void Delete(BranchModel branch)
        {
            _Branch.RemoveBranch(branch);
        }
        [HttpPost]
        [Route("Admin/Edit")]
        public void Edit(BranchModel branch)
        {
            _Branch.EditBranch(branch);
        }
    }
}
