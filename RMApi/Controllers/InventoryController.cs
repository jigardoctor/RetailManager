using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class InventoryController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IInventoryData _inventoryData;

        public InventoryController(IConfiguration config, IInventoryData inventoryData)
        {
          _config = config;
           _inventoryData = inventoryData;
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]

        public List<InventoryModel> Get()
        {
          //  InventoryData data = new InventoryData(_config);
            return _inventoryData.GetInventory();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public void Post(InventoryModel item)
        {
            //InventoryData data = new InventoryData(_config);
            _inventoryData.SaveInventoryRecord(item);
        }

    }
}
