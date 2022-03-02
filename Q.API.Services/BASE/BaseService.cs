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
        private SwiftCodeBbsContext _context;
        /// <summary>
        /// 使用构造函数来定义上下文
        /// </summary>
        public BaseService()
        {
            _context=new SwiftCodeBbsContext();
        }
        /// <summary>
        /// 暴露给Dbcontext 提供给自定义仓储使用
        /// </summary>
        /// <returns></returns>
        protected SwiftCodeBbsContext bbsContext()
        { 
        return _context;
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
            _context.Set<TEntity>().Remove(entity);
            if (autosave)
            {
                await _context.SaveChangesAsync(cancellationToken);  
            }
          
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
            var dbset = _context.Set<TEntity>();
            var entitis = await dbset.Where(expression).ToListAsync(cancellationToken);
            await DeleteMantAsync(entitis, autosave, cancellationToken);
            if (autosave)
            {
                await _context.SaveChangesAsync(cancellationToken);
            }

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
            _context.RemoveRange(entities);
            if (autosave)
            {
                await _context.SaveChangesAsync(cancellationToken); 
            }
           
        }
        /// <summary>
        /// 根据筛选条件获取数据，如果不存在就返回一个NULL
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="autosave"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression, bool autosave = false, CancellationToken cancellationToken = default)
        {
            return _context.Set<TEntity>().Where(expression).SingleOrDefaultAsync(cancellationToken);
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
            var entity = await FindAsync(expression, autosave, cancellationToken);
            ///数据不存在触发异常
            if (entity==null)
            {
                throw new Exception(nameof(TEntity) + "：数据不存在");
            }
            return entity;
        }
        /// <summary>
        /// 获取一共多少条数
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<long> GetCountAsync(CancellationToken cancellationToken = default)
        {
            return _context.Set<TEntity>().LongCountAsync(cancellationToken);
        }
        /// <summary>
        /// 根据条件返回对应的条数
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<long> GetCountAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            return _context.Set<TEntity>().Where(expression).LongCountAsync(cancellationToken);
        }
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default)
        {
            return _context.Set<TEntity>().ToListAsync(cancellationToken);
        }
        /// <summary>
        /// 根据筛选条件查询数据
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="autosave"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression, bool autosave = false, CancellationToken cancellationToken = default)
        {
           return _context.Set<TEntity>().Where(expression).ToListAsync(cancellationToken); 
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
        public Task<List<TEntity>> GetPageedListAsync(int skipcount, int maxResultCount, string sorting, CancellationToken cancellationToken = default)
        {
            return _context.Set<TEntity>().OrderBy(sorting).Skip(skipcount).Take(maxResultCount).ToListAsync(cancellationToken);
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
            var saveentity = (await _context.Set<TEntity>().AddAsync(entity, cancelllationToken)).Entity;
            if (autosave)//是否马上更新到数据
            { 
               await _context.SaveChangesAsync(cancelllationToken);
            }
            return saveentity;
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
            var entityArray = entities.ToArray();
            await _context.Set<TEntity>().AddRangeAsync(entityArray, cancellationToken);
            if (autosace)
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
          
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
            _context.Set<TEntity>().UpdateRange(entitys);

            if (autosave)
            {
                await _context.SaveChangesAsync(cancelllationToken);
            }
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
            _context.Attach(entity);
            var UpdateEntity = _context.Update(entity).Entity;
            if (autosave)
            {
                await _context.SaveChangesAsync(cancellationToken);
            }

            return UpdateEntity;
        }
    }
}
