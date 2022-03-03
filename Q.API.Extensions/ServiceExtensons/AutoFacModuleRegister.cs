using Autofac;
using Q.API.IRespostories.BASE;
using Q.API.IServices;
using Q.API.Respostories.BASE;
using Q.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.API.Extensions.ServiceExtensons
{
    public class AutoFacModuleRegister:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ArticleService>().As<IArticleService>();
            builder.RegisterGeneric(typeof(BaseRespostory<>)).As(typeof(IBaseRespostory<>)).InstancePerDependency();//基类泛型依赖注入
        }
    }
}
