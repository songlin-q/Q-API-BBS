using Microsoft.AspNetCore.Mvc;
using Q.API.IServices;
using Q.API.Services;

namespace Q.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatController : ControllerBase
    {
        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        [HttpGet]
        public int get(int i,int j)
        {
            ICalculateService calculateService = new CalculateSerivce();
            return calculateService.Sum(i,j);
        }
    }
}
