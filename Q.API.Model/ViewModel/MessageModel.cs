using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.API.Model.ViewModel
{
    /// <summary>
    /// 消息数据类
    /// </summary>
    public class MessageModel<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 返回的信息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 消息集合
        /// </summary>
        public T response { get; set; }
    }
}
