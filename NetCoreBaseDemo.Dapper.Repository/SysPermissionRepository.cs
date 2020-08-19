using NetCoreBaseDemo.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TheAcme.EntityModule;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseDemo.Dapper.Repository
{
    public class SysPermissionRepository : BaseRepository<string, SysPermission>, ISysPermissionRepository
    {
        // protected IDbConnection _dbConnection;
        public SysPermissionRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }


    }
}
