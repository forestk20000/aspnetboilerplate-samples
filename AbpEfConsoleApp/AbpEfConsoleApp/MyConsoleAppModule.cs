using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;

namespace AbpEfConsoleApp
{
    //Defining a module depends on AbpEntityFrameworkModule
    [DependsOn(typeof(AbpEntityFrameworkModule))]
    public class MyConsoleAppModule : AbpModule
    {
        public override void Initialize()
        {
            // 按约定注册程序集
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}