﻿using Microsoft.Extensions.Configuration;
using RMDataManager.Library.Internal.DataAccess;
using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library.DataAccess
{
    public class InventoryData : IInventoryData
    {
        //private readonly IConfiguration _config;
        private readonly ISqlDataAccess _sqlDataAccess;

        public InventoryData( ISqlDataAccess sqlDataAccess)
        {
          //  _config = config;
            _sqlDataAccess = sqlDataAccess;
        }
        public List<InventoryModel> GetInventory()
        {
           // SqlDataAccess sql = new SqlDataAccess(_config);
            var output = _sqlDataAccess.LoadData<InventoryModel, dynamic>("dbo.spInventory_GetAll", new { }, "RMData");
            return output;
        }

        public void SaveInventoryRecord(InventoryModel item)
        {
           // SqlDataAccess sql = new SqlDataAccess(_config);
            _sqlDataAccess.SaveData<InventoryModel>("dbo.spInventory_Insert", item, "RMData");
        }
    }
}
