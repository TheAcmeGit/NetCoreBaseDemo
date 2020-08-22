using AutoMapper;
using NetCoreBaseDemo.DBEntity.Base;
using NetCoreBaseDemo.IRepository;
using NetCoreBaseDemo.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBaseDemo.Service
{
    public class BaseService<TKey, TEntity,TEntityDto> where TEntity : class, new()
    {
        protected IBaseRepository<TKey, TEntity> _baseRepository;
        protected  IMapper _mapper;

        public TEntity Get(TKey id)
        {
            return _baseRepository.Get(id);
        }
        public TKey Insert(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntityDto, TEntity>(entityDto);
            return _baseRepository.Insert(entity);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }
        public ResponseTable<TEntity> GetListPaged(int pageNumber, int rowsPerPage, string conditions, string orderby, object parameters = null)
        {
            int total = 0;
            ResponseTable<TEntity> table = new ResponseTable<TEntity>();
            table.TableData = _baseRepository.GetListPaged(out total, pageNumber, rowsPerPage, conditions, orderby, parameters);
            table.Total = total;
            return table;
        }

        public int Update(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntityDto, TEntity>(entityDto);
            return _baseRepository.Update(entity);
        }
        public int Delete(TKey id)
        {
            return _baseRepository.Delete(id);
        }
        public int GetTotalCount(string conditions, object parameters = null)
        {
            return 0;
        }
    }
}
