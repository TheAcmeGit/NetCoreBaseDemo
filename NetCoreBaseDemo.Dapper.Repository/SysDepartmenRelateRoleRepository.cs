using NetCoreBaseDemo.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TheAcme.EntityModule;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseDemo.Dapper.Repository
{
    public class SysDepartmenRelateRoleRepository : BaseRepository< string, SysDepartmenRelateRole>, ISysDepartmenRelateRoleRepository
    {
        // protected IDbConnection _dbConnection;
        public SysDepartmenRelateRoleRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }


    }
}
