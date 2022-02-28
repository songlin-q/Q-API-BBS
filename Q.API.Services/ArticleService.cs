using Q.API.IRespostories;
using Q.API.IServices;
using Q.API.Model;
using Q.API.Respostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Q.API.Services
{
    public class ArticleService : IArticleService
    {
        public readonly IArticleRepository dal;
        public ArticleService()//使用构造函数的形式进行添加
        { 
        this.dal= new ArticleRepository();
        }
        public void Add(Article article)
        {
            dal.Add(article);
        }

        public void Delete(Article article)
        {
            dal.Delete(article);
        }

        public List<Article> Query(Expression<Func<Article, bool>> whereExpression)
        {
            return dal.Query(whereExpression);
        }

        public void Update(Article article)
        {
            dal.Update(article);
        }
    }
}
