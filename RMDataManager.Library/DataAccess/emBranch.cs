using Microsoft.Extensions.Configuration;
using RMDataManager.Library.Internal.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMDataManager.Library.DataAccess
{
    public class emBranch : IemBranch
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        public emBranch(ISqlDataAccess sql)
        {
            _sqlDataAccess = sql;
        }
        public List<emBranch> GetBranch()
        {
            // SqlDataAccess sql = new SqlDataAccess(_config);
            var output = _sqlDataAccess.LoadData<emBranch, dynamic>("dbo.Branch_GetAll", new { }, "RMData");
            return output;

        }
        public emBranch GetBranchByid(int Idbranch)
        {
            //SqlDataAccess sql = new SqlDataAccess(_config);
            var output = _sqlDataAccess.LoadData<emBranch, dynamic>("dbo.Branch_GetById", new { IdBranch = Idbranch }, "RMData").FirstOrDefault();
            return output;

        }
    }
}
