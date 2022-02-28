using Q.API.IRespostories;
using Q.API.Model;
using Q.API.Respostories.EfContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Q.API.Respostories
{
    /// <summary>
    /// 实现仓储接口
    /// </summary>
    public class ArticleRepository : IArticleRepository
    {
        /// <summary>
        /// 这里使用私有属性，为以后的单例模式做准备
        /// </summary>
        private SwiftCodeBbsContext context;
        public ArticleRepository()
        { 
        this.context = new SwiftCodeBbsContext();
        }
        public void Add(Article article)
        {
            context.articles.Add(article);
            context.SaveChanges();  

        }

        public void Delete(Article article)
        {
            context.articles.Remove(article);
            context.SaveChanges();
        }

        public List<Article> Query(Expression<Func<Article, bool>> whereExpression)
        {
            return context.articles.Where(whereExpression).ToList();
        }

        public void Update(Article article)
        {
            context.articles.Update(article);
            context.SaveChanges();
        }
    }
}
