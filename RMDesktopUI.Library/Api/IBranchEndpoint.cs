using RMDesktopUI.Library.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Api
{
    public interface IBranchEndpoint
    {
        Task AddBranch(BranchModel brancmodel);
        Task<List<BranchModel>> GetAll();
        Task RemoveBranch(BranchModel brancmodel);
        Task EditBranch(BranchModel brancmodel);
    }
}