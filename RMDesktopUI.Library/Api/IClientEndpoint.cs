using RMDesktopUI.Library.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Api
{
    public interface IClientEndpoint
    {
        Task AddBranch(ClientModel clientmodel);
        Task EditBranch(ClientModel clientmodel);
        Task<List<ClientModel>> GetAll();
        Task RemoveBranch(ClientModel clientmodel);
    }
}