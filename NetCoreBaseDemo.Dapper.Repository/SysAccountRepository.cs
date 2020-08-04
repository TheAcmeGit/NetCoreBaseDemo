using NetCoreBaseDemo.DBEntity;
using NetCoreBaseDemo.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NetCoreBaseDemo.Dapper.Repository
{
    public class SysAccountRepository : BaseRepository<Guid, SysAccount>, ISysAccountRepository
    {
        public SysAccountRepository(IDbConnection dbConnection) : base(dbConnection)
        {

        }
    }
}
