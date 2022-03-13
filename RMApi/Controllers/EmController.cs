using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMDataManager.Library.DataAccess;
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
        private readonly IemBranch _embranch;

        public EmController(IemBranch embranch)
        {
            _embranch = embranch;
        }

        [HttpGet]
        public List<emBranch> Get()
        {
            //ProductData data = new ProductData(_config);
            return _embranch.GetBranch();
        }
    }
}
