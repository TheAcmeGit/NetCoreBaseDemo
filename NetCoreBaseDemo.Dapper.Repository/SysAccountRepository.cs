using NetCoreBaseDemo.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TheAcme.EntityModule;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseDemo.Dapper.Repository
{
    public class SysAccountRepository : BaseRepository< string, SysAccount>, ISysAccountRepository
    {
        protected IDbConnection _dbConnection;
        public SysAccountRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            base._dbBaseConnection = dbConnection;
        }


    }
}
