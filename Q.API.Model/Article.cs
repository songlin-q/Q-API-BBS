﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.API.Model
{
    /// <summary>
    /// 文章类
    /// </summary>
    public class Article
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
       /// <summary>
       /// 创建人
       /// </summary>
        public string Submitter { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 访问量
        /// </summary>
        public int Traffic { get; set; }
        /// <summary>
        /// 评论数量
        /// </summary>
        public int CommentNum { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 是否删除(逻辑删除)
        /// </summary>
        public bool? IsDeleted { get; set; }
    }
}
