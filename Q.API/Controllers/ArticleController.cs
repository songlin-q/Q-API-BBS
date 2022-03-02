using Microsoft.AspNetCore.Mvc;
using Q.API.IServices;
using Q.API.Model;
using Q.API.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.API.Controllers
{
    /// <summary>
    /// 文章接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        /// <summary>
        /// 根据ID查询文章信息  
        /// </summary>
        /// <param name="Id"></param>  
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Article>> Get(int Id)
        {
            IArticleService articleService = new ArticleService();
            return await articleService.GetListAsync(s => s.Id == Id);

        }
    }
}
