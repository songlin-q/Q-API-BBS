using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Q.API.Coom;
using Q.API.Respostories.EfContext;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;  
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            #region swagger  配置swagger服务
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Version = "v1",
                    Title = "Q.API",
                    Description = "框架接口文档",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {

                        Name = "QAPI",
                        Email = "442534979@qq.com"
                    }

                });

                var basepath = AppContext.BaseDirectory;
                var xmlpath = Path.Combine(basepath, "Q.API.xml");

                c.IncludeXmlComments(xmlpath, true);

                var xmlmodel = Path.Combine(basepath, "Q.API.Model.xml");
                c.IncludeXmlComments(xmlmodel, true);

            });
            #endregion

            //依赖注入 Appsettings方法
            services.AddControllers();
            services.AddSingleton(new AppSettings(Configuration));//单例模注入


            #region jwt进行认证授权
            //1、进行授权
            services.AddSwaggerGen(c =>
            {
                //开启小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                //在header中添加token，传递到后台
                c.OperationFilter<SecurityRequirementsOperationFilter>();
                c.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输)，直接在下框中输入Bearer {token}注意两者之间有一个空格",
                    Name = "Authorization",//JWT默认的参数名称
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,//JWT默认Authorization存放的位置
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey


                });

            });

            //进行多角色方案
            services.AddAuthorization(option =>
            {
                option.AddPolicy("client", policy => policy.RequireRole("client").Build());//单独角色
                option.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                option.AddPolicy("AdminOrSystem", policy => policy.RequireRole("Admin", "System"));//或的关系
                option.AddPolicy("AdminAndSystem", policy => policy.RequireRole("Admin").RequireRole("System"));//且的关系

            });
            //2、进行认证
            services.AddAuthentication(x =>
            {
                //配置默认Authorization
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                var audienceConfig = Configuration["Audience:Audience"];
                var sysmmetriceKeyAsBase64 = Configuration["Audience:Secret"];
                var iss= Configuration["Audience:Issuer"];
                var keyByteArray = Encoding.ASCII.GetBytes(sysmmetriceKeyAsBase64);
                var signingKey = new SymmetricSecurityKey(keyByteArray);
                options.TokenValidationParameters = new TokenValidationParameters() {
                ValidateIssuerSigningKey=true,
                IssuerSigningKey=signingKey,
                //参数配置
                ValidateIssuer=true,
                ValidIssuer=iss,//发行人
                ValidateAudience=true,
                ValidAudience=audienceConfig,//订阅人
                ValidateLifetime=true,
                ClockSkew=TimeSpan.Zero,//这个是缓冲过期时间，也就是说，即使我们配置了过期时间，这里也要考虑进去，过期时间+缓冲，默认时间是七分钟，可以直接设置为0
                RequireExpirationTime=true
                
                };

            });
            #endregion


            #region 依赖注入EFcore
            services.AddDbContext<SwiftCodeBbsContext>(o => {
                //使用懒加载 只针对某个进行加载
                o.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=SwiftCodeBbs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;",oo=>
                oo.MigrationsAssembly("Q.API.Respostories"));//迁移到这个项目中
            });
      
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            #region swagger  配置中间件
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.RoutePrefix = "";//无论本地还是服务器都会默认是swagger页面

            });
            #endregion

            app.UseStaticFiles();

            app.UseRouting();

            //开启认证
            app.UseAuthentication();
            //授权中间件
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
