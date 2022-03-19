using Microsoft.Extensions.Configuration;
using RMDataManager.Library.Internal.DataAccess;
using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMDataManager.Library.DataAccess
{
    public class BranchData : IBranchData
    {
        private readonly ISqlDataAccess _sql;
        public BranchData(ISqlDataAccess sql)
        {
            _sql = sql;
        }
        public List<BranchModel> GetBranch()
        {
            // SqlDataAccess sql = new SqlDataAccess(_config);
            var output = _sql.LoadData<BranchModel, dynamic>("dbo.emBranch_GetAll", new { }, "RMData");
            return output;

        }
        public List<BranchModel> GetBranchByid(int Idbranch)
        {
            //SqlDataAccess sql = new SqlDataAccess(_config);
            var p = new { Id = Idbranch };
            var output = _sql.LoadData<BranchModel, dynamic>("dbo.emBranch_GetById", p, "RMData");
            return output;

        }
        public void AddBranch(BranchModel branch)
        {
            _sql.StartTransaction("RMData");
            _sql.SaveDataInTransaction<BranchModel>("dbo.emBranch_Add", branch);

        }
        public void RemoveBranch(BranchModel branch)
        {
            var p = new { Id = branch.IdBranch };
            _sql.SaveData("dbo.emBranch_Remove",p, "RMData");

        }
        public void EditBranch(BranchModel branch)
        {
            //var p = new { IdBranch = branch.IdBranch ,BranchName= branch.BranchName,Ho =branch.Ho};
            //_sql.SaveData("dbo.emBranch_Edit", p, "RMData");
            _sql.StartTransaction("RMData");
            _sql.SaveDataInTransaction<BranchModel>("dbo.emBranch_Edit", branch);
        }
    }
}
