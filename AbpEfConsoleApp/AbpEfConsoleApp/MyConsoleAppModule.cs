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
            // ��Լ��ע�����
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}