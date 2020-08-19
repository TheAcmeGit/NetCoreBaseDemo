using NetCoreBaseDemo.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TheAcme.EntityModule;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseDemo.Dapper.Repository
{
    public class SysPermissionsRepository : BaseRepository<string, SysPermission>, ISysPermissionsRepository
    {
        // protected IDbConnection _dbConnection;
        public SysPermissionsRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }


    }
}
