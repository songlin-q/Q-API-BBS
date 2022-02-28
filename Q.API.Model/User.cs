using System;

namespace Q.API.Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int egg { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string sex { get; set; }
    }
}
