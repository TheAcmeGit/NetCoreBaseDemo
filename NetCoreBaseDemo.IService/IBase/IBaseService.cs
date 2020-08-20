using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBaseDemo.IService
{
    public interface IBaseService<TKey,TEntity> where TEntity:class ,new()
    {
        public TEntity Get(TKey id);
        public IEnumerable<TEntity> GetAll();
        public TKey Insert(TEntity entity);
    }
}
