using NetCoreBaseDemo.DBEntity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBaseDemo.IService
{
    public interface IBaseService<TKey,TEntity, SysAccountDto> where TEntity:class ,new()
    {
         TEntity Get(TKey id);
         IEnumerable<TEntity> GetAll();
        TKey Insert(SysAccountDto entity);
        int Update(SysAccountDto entity);
        int Delete(TKey id);
        ResponseTable<TEntity> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby, object parameters = null);
    }
}
