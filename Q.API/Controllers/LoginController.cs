using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Q.API.Coom.Helper;
using Q.API.Model;
using System.Threading.Tasks;

namespace Q.API.Controllers
{
   /// <summary>
   /// 登录接口
   /// </summary>
    

    [ApiController]
    [Route("[controller]")]

    public class LoginController : Controller
    {
        /// <summary>
        /// 获取JWT令牌
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetJwtst(string name,string pass)
        {
            //将用户Id和角色单独自定义标量，封装进token字符中
            TokenJwtModel tokenModel = new TokenJwtModel() { uID=1,Role="Admin"};
            var jwtstr=JwtHelper.IssueJet(tokenModel);//登录获取到一定规则的令牌
            var suc = true;

            return Ok(new {
            
             success= suc,
             token= jwtstr
            });
        }
    }
}
