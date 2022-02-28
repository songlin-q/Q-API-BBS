using Q.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Q.API.IRespostories
{
    /// <summary>
    /// 文章仓储接口
    /// </summary>
    public interface IArticleRepository
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="article"></param>
        void Add(Article article);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="article"></param>
        void Delete(Article article);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="article"></param>
        void Update(Article article);
        /// <summary>
        /// 通过Linq语句或者lamda表达式返回集合
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        List<Article> Query(Expression<Func<Article, bool>> whereExpression);

    }
}
