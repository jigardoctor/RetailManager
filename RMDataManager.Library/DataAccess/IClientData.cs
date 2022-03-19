using RMDataManager.Library.Models;
using System.Collections.Generic;

namespace RMDataManager.Library.DataAccess
{
    public interface IClientData
    {
        void Addclient(ClientModel client);
        void Editclient(ClientModel client);
        List<ClientModel> Getclient();
        List<ClientModel> GetclientByid(int Idclient);
        void Removeclient(ClientModel client);
    }
}