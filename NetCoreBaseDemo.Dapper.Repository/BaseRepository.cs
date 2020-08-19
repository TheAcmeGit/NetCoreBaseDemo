using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace NetCoreBaseDemo.Dapper.Repository
{
    public class BaseRepository<TKey,TEntity> where TEntity:class,new ()
    {
        protected  IDbConnection _dbBaseConnection;

      
        public TEntity Get(TKey id)
        {
            //   return _dbBaseConnection.Get<TEntity>(id);
            return _dbBaseConnection.Get<TEntity>(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _dbBaseConnection.GetList<TEntity>();
        }
        public IEnumerable<TEntity> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby, object parameters = null)
        {

            return _dbBaseConnection.GetListPaged<TEntity>(pageNumber, rowsPerPage, conditions, orderby, parameters);
        }
        public TKey Insert(TEntity entity)
        {

            return _dbBaseConnection.Insert<TKey, TEntity>(entity);
        }
        public int Delete(TKey id)
        {
            return _dbBaseConnection.Delete<TEntity>(id);
        }

        public int Delete(TEntity entity)
        {
            return _dbBaseConnection.Delete<TEntity>(entity);
        }

        public int Update(TEntity entity)
        {
            return _dbBaseConnection.Update<TEntity>(entity);
        }
    }
}
