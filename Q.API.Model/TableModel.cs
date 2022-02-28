using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.API.Model
{
    /// <summary>
    /// 负责表数据
    /// </summary>
    public class TableModel<T>
    {
        /// <summary>
        /// 返回的编码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 返回的信息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 记录总数
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 返回的结果
        /// </summary>
        public List<T> Data { get; set; }
    }
}
