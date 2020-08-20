using NetCoreBaseDemo.IRepository;
using NetCoreBaseDemo.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBaseDemo.Service
{
    public class BaseService<TKey, TEntity> where TEntity : class, new()
    {
        protected IBaseRepository<TKey, TEntity> _baseRepository;

        public TEntity Get(TKey id)
        {
            return _baseRepository.Get(id);
        }
        public TKey Insert(TEntity entity)
        {
            return _baseRepository.Insert(entity);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }
    }
}
