using System.Collections.Generic;

namespace RMDataManager.Library.DataAccess
{
    public interface IemBranch
    {
        List<emBranch> GetBranch();
        emBranch GetBranchByid(int Idbranch);
    }
}