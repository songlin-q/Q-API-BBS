using Microsoft.EntityFrameworkCore;
using Q.API.IRespostories.BASE;
using Q.API.Respostories.EfContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Q.API.Respostories.BASE
{
    /// <summary>
    /// 仓储接口实现
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        private readonly IBaseRespostory<TEntity> _BaseRespostories;
        /// <summary>
        /// 使用构造函数进行依赖注入
        /// </summary>
        public BaseService(IBaseRespostory<TEntity> baseRespostory)
        {
            _BaseRespostories = baseRespostory;
        }

        /// <summary>
        /// 根据实体删除一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="autosave"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task DeleteAsync(TEntity entity, bool autosave = false, CancellationToken cancellationToken = default)
        {
            await _BaseRespostories.DeleteAsync(entity, autosave, cancellationToken);


        }
        /// <summary>
        /// 根据筛选条件删除数据
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="autosave"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task DeleteAsync(Expression<Func<TEntity, bool>> expression, bool autosave = false, CancellationToken cancellationToken = default)
        {
           await _BaseRespostories.DeleteAsync(expression, autosave, cancellationToken);

        }
        /// <summary>
        ///根据实体集合删除数据
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="autosave"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task DeleteMantAsync(IEnumerable<TEntity> entities, bool autosave = false, CancellationToken cancellationToken = default)
        {
            await _BaseRespostories.DeleteMantAsync(entities,autosave,cancellationToken);
        }
        /// <summary>
        /// 根据筛选条件获取数据，如果不存在就返回一个NULL
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="autosave"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression, bool autosave = false, CancellationToken cancellationToken = default)
        {
           return await _BaseRespostories.FindAsync(expression, autosave, cancellationToken);
        }
        /// <summary>
        /// 根据条件返回数据，如果不存在则抛出异常
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="autosave"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, bool autosave = false, CancellationToken cancellationToken = default)
        {
            return await _BaseRespostories.GetAsync(expression, autosave, cancellationToken);
        }
        /// <summary>
        /// 获取一共多少条数
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<long> GetCountAsync(CancellationToken cancellationToken = default)
        {
            return await _BaseRespostories.GetCountAsync(cancellationToken);
        }
        /// <summary>
        /// 根据条件返回对应的条数
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<long> GetCountAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _BaseRespostories.GetCountAsync(cancellationToken);
        }
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default)
        {
            return await _BaseRespostories.GetListAsync(cancellationToken);
        }
        /// <summary>
        /// 根据筛选条件查询数据
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="autosave"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression, bool autosave = false, CancellationToken cancellationToken = default)
        {
            return await _BaseRespostories.GetListAsync(cancellationToken);
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="skipcount"></param>
        /// <param name="maxResultCount"></param>
        /// <param name="sorting"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<TEntity>> GetPageedListAsync(int skipcount, int maxResultCount, string sorting, CancellationToken cancellationToken = default)
        {
            return await _BaseRespostories.GetPageedListAsync(skipcount,maxResultCount,sorting,cancellationToken);
        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="autosave"></param>
        /// <param name="cancelllationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<TEntity> InsertAsync(TEntity entity, bool autosave = false, CancellationToken cancelllationToken = default)
        {
           return await _BaseRespostories.InsertAsync(entity, autosave, cancelllationToken);
        }
        /// <summary>
        /// 接口说明批量插入多条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="autosace"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task InsertManyAsync(List<TEntity> entities, bool autosace = false, CancellationToken cancellationToken = default)
        {
            await _BaseRespostories.InsertManyAsync(entities, autosace, cancellationToken);

        }
        /// <summary>
        /// 批量更新实体模型
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="autosave"></param>
        /// <param name="cancelllationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task UpdateMantAsync(IEnumerable<TEntity> entitys, bool autosave = false, CancellationToken cancelllationToken = default)
        {
            await _BaseRespostories.UpdateMantAsync(entitys, autosave, cancelllationToken);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="autosave"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TEntity> UpdateAsync(TEntity entity, bool autosave = false, CancellationToken cancellationToken = default)
        {
            //Attach 是将一个处于Detached的Entity附加到上下文，而附加到上下文后的这一Entity的state为Unchanged.传递到Attach方法的对象必须具有有效的EntityKey的值
           return await _BaseRespostories.UpdateAsync(entity, autosave, cancellationToken);
        }
    }
}
