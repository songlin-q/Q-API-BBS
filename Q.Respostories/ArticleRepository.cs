using Q.API.IRespostories;
using Q.API.IRespostories.BASE;
using Q.API.Model;
using Q.API.Respostories.BASE;
using Q.API.Respostories.EfContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Q.API.Respostories
{
    /// <summary>
    /// 实现仓储接口
    /// </summary>
    public class ArticleRepository: BaseRespostory<Article>,IArticleRepository
    {

    }
}
