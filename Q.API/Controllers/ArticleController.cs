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
        private readonly IArticleService _articleService;
        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="articleService"></param>
        public ArticleController(IArticleService articleService)
        { 
           this._articleService=articleService;
        }
        /// <summary>
        /// 根据ID查询文章信息  
        /// </summary>
        /// <param name="Id"></param>  
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Article>> Get(int Id)
        {
            
            return await _articleService.GetListAsync(s => s.Id == Id);

        }
    }
}
