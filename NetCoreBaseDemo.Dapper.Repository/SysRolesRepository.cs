using NetCoreBaseDemo.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TheAcme.EntityModule;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseDemo.Dapper.Repository
{
    public class SysRolesRepository : BaseRepository<string, SysRole>, ISysRolesRepository
    {
        // protected IDbConnection _dbConnection;
        public SysRolesRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }


    }
}
