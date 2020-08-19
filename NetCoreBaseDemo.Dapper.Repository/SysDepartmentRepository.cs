using NetCoreBaseDemo.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TheAcme.EntityModule;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseDemo.Dapper.Repository
{
    public class SysDepartmentRepository : BaseRepository< string, SysDepartment>, ISysDepartmentRepository
    {
        // protected IDbConnection _dbConnection;
        public SysDepartmentRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }


    }
}
