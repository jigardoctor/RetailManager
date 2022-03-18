using RMDataManager.Library.Models;
using System.Collections.Generic;

namespace RMDataManager.Library.DataAccess
{
    public interface IBranchData
    {
        void AddBranch(BranchModel branch);
        List<BranchModel> GetBranch();
        List<BranchModel> GetBranchByid(int Idbranch);
        void RemoveBranch(BranchModel branch);
        void EditBranch(BranchModel branch);
    }
}