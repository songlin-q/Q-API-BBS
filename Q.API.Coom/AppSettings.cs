using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Q.API.Coom
{
    /// <summary>
    /// 该类用于获取appsetting.Json的参数列表
    /// </summary>
    public class AppSettings
    {
        static IConfiguration Configuration { get; set; }
        static string contentpath { get; set; }

        //public AppSeettings(string contentpath)
        //{
        //    string path = "appsettings.json";
        //    //如果配置文件是根据环境变量来区分的，可以这样进行配置
        //    //path = $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json";
        //    configuration = new ConfigurationBuilder().SetBasePath(contentpath)
        //        .Add(new );

        //}

        public AppSettings(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// 封装要操作的字符
        /// </summary>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static string app(params string[] sections)
        {
            try
            {
                if (sections.Any())
                {
                    return Configuration[string.Join(":",sections)];
                }
            }
            catch (Exception)
            {

                throw;
            }
            return "";
        }
        /// <summary>
        /// 递归获取配置数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> app<T>(params string[] sections)
        {
            List<T> lists = new List<T>();
            Configuration.Bind(string.Join(":",sections),lists);
            return lists;
        
        }

    }
}
