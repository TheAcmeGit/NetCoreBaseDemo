using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace NetCoreBaseDemo.Dapper.Repository
{
    public class BaseRepository<TKey,TEntity> where TEntity:class,new ()
    {
        protected readonly IDbConnection _dbConnection;

        public BaseRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public TEntity Get(TKey id)
        {
            return _dbConnection.Get<TEntity>(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _dbConnection.GetList<TEntity>();
        }
        public IEnumerable<TEntity> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby, object parameters = null)
        {
            return _dbConnection.GetListPaged<TEntity>(pageNumber, rowsPerPage, conditions, orderby, parameters);
        }
        public TKey Insert(TEntity entity)
        {
            return _dbConnection.Insert<TKey, TEntity>(entity);
        }
        public int Delete(TKey id)
        {
            return _dbConnection.Delete<TEntity>(id);
        }

        public int Delete(TEntity entity)
        {
            return _dbConnection.Delete<TEntity>(entity);
        }

        public int Update(TEntity entity)
        {
            return _dbConnection.Update<TEntity>(entity);
        }
    }
}
