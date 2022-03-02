using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Q.API.IRespostories.BASE
{
    /// <summary>
    /// 仓储基类接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRespostory<TEntity> where TEntity : class
    {
        /// <summary>
        /// 接口描述：插入数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="autosave">是否马上更新到数据库</param>
        /// <param name="cancelllationToken">是否取消令牌(CancellationToken是取消状态，task内部为启动的任务不会启动新线程)</param>
        /// <returns></returns>
        Task<TEntity> InsertAsync(TEntity entity, bool autosave = false, CancellationToken cancelllationToken = default);
        /// <summary>
        /// 接口描述：批量插入数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="autosace">是否马上更新到数据库</param>
        /// <param name="cancellationToken">是否取消令牌，当(CancellationToken是取消状态时，Task内部未启动的任务不会启动新的线程)</param>
        /// <returns></returns>
        Task InsertManyAsync(List<TEntity> entity, bool autosace = false, CancellationToken cancellationToken = default);
        /// <summary>
        /// 接口描述：更新数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="autosave">是否马上更新到数据库</param>
        /// <param name="cancelllationToken">是否取消令牌，当(CancellationToken为取消状态时，Task内部未启动的任务不会自动启动新线程)</param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TEntity entity, bool autosave = false, CancellationToken cancelllationToken = default);
        /// <summary>
        /// 接口描述:批量更新数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="autosave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">是否取消令牌(CancellationToken是取消状态时，Task内部未启动的任务不会自动启动新的线程)</param>
        /// <returns></returns>
        Task UpdateMantAsync(IEnumerable<TEntity> entity, bool autosave = false, CancellationToken cancellationToken = default);
        /// <summary>
        /// 接口描述:根据实体删除一条数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="autosave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">是否取消令牌（当CancellationToken是取消状态时，Task内部未启动的不会自动新的线程）</param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity, bool autosave = false, CancellationToken cancellationToken = default);
        /// <summary>
        /// 接口描述：根据筛选条件删除数据
        /// </summary>
        /// <param name="expression">筛选条件，可以是lamda表达式，也可以是LINQ语句</param>
        /// <param name="autosave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">是否取消令牌（当CancellationToken是取消状态时，Task内部未启动的不会自动新的线程）</param>
        /// <returns></returns>
        Task DeleteAsync(Expression<Func<TEntity, bool>> expression, bool autosave = false, CancellationToken cancellationToken = default);
        /// <summary>
        /// 接口描述：根据实体集合删除数据
        /// </summary>
        /// <param name="entities">实体类</param>
        /// <param name="autosave">否马上更新到数据库</param>
        /// <param name="cancellationToken">是否取消令牌（当CancellationToken是取消状态时，Task内部未启动的不会自动新的线程）</param>
        /// <returns></returns>
        Task DeleteMantAsync(IEnumerable<TEntity> entities, bool autosave = false, CancellationToken cancellationToken = default);
        /// <summary>
        /// 接口描述:根据筛选条件获取一条数据(如果不存在则返回NULL)
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="autosave"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression, bool autosave = false, CancellationToken cancellationToken = default);
        /// <summary>
        /// 接口描述:根据筛选条件获取一条数据(如果不存在则抛出异常)
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="autosave"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, bool autosave = false, CancellationToken cancellationToken = default);
        /// <summary>
        /// 获取所有的数据
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// 接口描述:根据筛选条件来获取一个数据集合
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="autosave"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression, bool autosave = false, CancellationToken cancellationToken = default);
        /// <summary>
        /// 接口描述:分页查询数据
        /// </summary>
        /// <param name="skipcount">跳过多少条</param>
        /// <param name="maxResultCount">获取多少条</param>
        /// <param name="sorting">排序字段</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetPageedListAsync(int skipcount, int maxResultCount, string sorting, CancellationToken cancellationToken = default);
        /// <summary>
        /// 接口描述:获取总共多少条数据
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<long> GetCountAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// 接口描述:根据条件获取筛选数据条数
        /// </summary>
        /// <param name="expression">筛选条件</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<long> GetCountAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);

    }


}
