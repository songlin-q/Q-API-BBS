using Q.API.IRespostories;
using Q.API.IRespostories.BASE;
using Q.API.IServices;
using Q.API.Model;
using Q.API.Respostories;
using Q.API.Respostories.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Q.API.Services
{
    public class ArticleService : BaseService<Article>, IArticleService
    {
        public ArticleService(IBaseRespostory<Article> baseRespository) : base(baseRespository)//依赖注入
        { 
        
        }
    }
}
