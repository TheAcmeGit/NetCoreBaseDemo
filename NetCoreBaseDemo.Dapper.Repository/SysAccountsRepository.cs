using NetCoreBaseDemo.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TheAcme.EntityModule;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseDemo.Dapper.Repository
{
    public class SysAccountsRepository : BaseRepository< string, SysAccount>, ISysAccountsRepository
    {
        // protected IDbConnection _dbConnection;
        public SysAccountsRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }


    }
}
