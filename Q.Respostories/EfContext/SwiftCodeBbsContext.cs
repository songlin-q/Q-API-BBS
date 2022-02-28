using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Q.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.API.Respostories.EfContext
{
    /// <summary>
    /// 创建数据库上下文  将代码生成相对于的配置文件
    /// </summary>
    public class SwiftCodeBbsContext:DbContext
    {
        public SwiftCodeBbsContext()
        { 
        
        }
        /// <summary>
        /// 使用构造函数
        /// </summary>
        /// <param name="options"></param>
        public SwiftCodeBbsContext(DbContextOptions<SwiftCodeBbsContext> options) : base(options)
        { 
        
        }

        public DbSet<Article> articles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //设置字段类型长度
            modelBuilder.Entity<Article>().Property(p => p.Title).HasMaxLength(128);
            modelBuilder.Entity<Article>().Property(p => p.Submitter).HasMaxLength(64);
            modelBuilder.Entity<Article>().Property(p => p.Category).HasMaxLength(256);
            modelBuilder.Entity<Article>().Property(p => p.Content).HasMaxLength(128);
            modelBuilder.Entity<Article>().Property(p => p.Remark).HasMaxLength(1024);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            //反向生成到数据库
            //使用sql语句进行创建  配置链接字符串
            dbContextOptionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=SwiftCodeBbs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;")
                .LogTo(Console.WriteLine,LogLevel.Information);//日志打印

        }

    }
}
