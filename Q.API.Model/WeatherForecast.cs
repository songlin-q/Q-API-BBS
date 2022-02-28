using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.API.Model
{
    /// <summary>
    /// 天气预报
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 华摄氏度
        /// </summary>
        public int TemperatureC { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        public string summarys { get; set; }
    }
}
