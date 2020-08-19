using NetCoreBaseDemo.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TheAcme.EntityModule;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseDemo.Dapper.Repository
{
    public class SysRoleRepository : BaseRepository<string, SysRole>, ISysRoleRepository
    {
        // protected IDbConnection _dbConnection;
        public SysRoleRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }


    }
}
