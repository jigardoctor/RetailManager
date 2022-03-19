using RMDataManager.Library.Internal.DataAccess;
using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMDataManager.Library.DataAccess
{
    public class ClientData : IClientData
    {
        private readonly ISqlDataAccess _sql;
        public ClientData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public List<ClientModel> Getclient()
        {
            // SqlDataAccess sql = new SqlDataAccess(_config);
            var output = _sql.LoadData<ClientModel, dynamic>("dbo.emClient_GetAll", new { }, "RMData");
            return output;

        }
        public List<ClientModel> GetclientByid(int Idclient)
        {
            //SqlDataAccess sql = new SqlDataAccess(_config);
            var p = new { Id = Idclient };
            var output = _sql.LoadData<ClientModel, dynamic>("dbo.emClient_GetById", p, "RMData");
            return output;

        }
        public void Addclient(ClientModel client)
        {
            _sql.StartTransaction("RMData");
            _sql.SaveDataInTransaction<ClientModel>("dbo.emClient_Add", client);

        }
        public void Removeclient(ClientModel client)
        {
            var p = new { Id = client.IdClient };
            _sql.SaveData("dbo.emBranch_Remove", p, "RMData");

        }
        public void Editclient(ClientModel client)
        {
            _sql.StartTransaction("RMData");
            _sql.SaveDataInTransaction<ClientModel>("dbo.emClient_Edit", client);
        }

    }
}
