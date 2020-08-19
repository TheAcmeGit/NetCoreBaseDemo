using NetCoreBaseDemo.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TheAcme.EntityModule;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseDemo.Dapper.Repository
{
    public class SysDepartmentsRepository : BaseRepository< string, SysDepartment>, ISysDepartmentsRepository
    {
        // protected IDbConnection _dbConnection;
        public SysDepartmentsRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }


    }
}
