using RMDesktopUI.Library.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Api
{
    public interface IUserEndpoint
    {
        Task<List<UserModel>> GetAll();
    }
}