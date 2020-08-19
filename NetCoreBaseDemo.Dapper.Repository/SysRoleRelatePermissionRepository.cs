using NetCoreBaseDemo.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TheAcme.EntityModule;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseDemo.Dapper.Repository
{
    public class SysRoleRelatePermissionRepository : BaseRepository<string, SysRoleRelatePermission>, ISysRoleRelatePermissionRepository
    {
        // protected IDbConnection _dbConnection;
        public SysRoleRelatePermissionRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }


    }
}
