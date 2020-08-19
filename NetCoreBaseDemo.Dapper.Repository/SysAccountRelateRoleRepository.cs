using NetCoreBaseDemo.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TheAcme.EntityModule;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseDemo.Dapper.Repository
{
    public class SysAccountRelateRoleRepository : BaseRepository< string, SysAccountRelateRole>, ISysAccountRelateRoleRepository
    {
        // protected IDbConnection _dbConnection;
        public SysAccountRelateRoleRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }


    }
}
