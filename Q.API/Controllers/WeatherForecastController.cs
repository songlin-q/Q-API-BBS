using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Q.API.Model;
using Q.API.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Q.API.Controllers
{
    /// <summary>
    /// 天气预报
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
        //定义数组
        private static readonly string[] Summaries = new[] {

        "Freezing","Bracing","Chilly","Cool","Mild","Warm","Balmy","Hot","Sweltering","Scorching"
        };

        private readonly ILogger<HomeController> _logger;
        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="logger"></param>
        public WeatherForecastController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 加法属性
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi =true)]//忽略API  当不想让某些API显示出来的时候可以使用此特性来隐藏
        public int Calculatevalue(int i,int j)
        {

            return i + j;
        }

        /// <summary>
        /// 获取天气
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),

                TemperatureC = rng.Next(-20, 55),
                summarys = Summaries[rng.Next(Summaries.Length)]

            }).ToArray();

        }

    }
}
