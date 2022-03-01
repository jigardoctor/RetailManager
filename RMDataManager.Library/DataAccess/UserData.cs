using Microsoft.Extensions.Configuration;
using RMDataManager.Library.Internal.DataAccess;
using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library.DataAccess
{
    public class UserData : IUserData
    {
        //private readonly IConfiguration _config;
        private readonly ISqlDataAccess _sql;

        public UserData(ISqlDataAccess sql)
        {
           // _config = config;
            _sql = sql;
        }
        public List<UserModel> GetUserById(string Id)
        {
            // SqlDataAccess sql = new SqlDataAccess(_config);
            var p = new { Id = Id };
            var output = _sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "RMData");
            return output;
        }
    }
}
