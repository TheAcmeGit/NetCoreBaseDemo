using System;
using System.Collections.Generic;

namespace NetCoreBaseDemo.IRepository
{
    public interface IBaseRepository<TKey, TEntity> where TEntity : class, new()
    {

        /// <summary>
        /// 根据主键获取实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(TKey id);
        /// <summary>
        /// 获取所有实体信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// 分页获取实体信息
        /// </summary>
        /// <param name="pageNumber">页码</param>
        /// <param name="rowsPerPage">每页条数</param>
        /// <param name="conditions">条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby, object parameters = null);
        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TKey Insert(TEntity entity);
        /// <summary>
        /// 根据Id删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(TKey id);
        /// <summary>
        /// 根据实体对象删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Delete(TEntity entity);
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Update(TEntity entity);
    }
}
