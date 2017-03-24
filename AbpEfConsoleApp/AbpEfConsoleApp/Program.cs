using System;
using Abp;
using Abp.Dependency;
using Castle.Facilities.Logging;

namespace AbpEfConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Bootstrapping ABP system
            // AbpBootstrapper 主要用于框架的基本配置的注册和初始化
            using (var bootstrapper = AbpBootstrapper.Create<MyConsoleAppModule>())
            {
                // 
                // Castle.Windsor.AddFacility 
                bootstrapper.IocManager
                    .IocContainer
                    .AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));

                // 
                bootstrapper.Initialize();

                // Getting a Tester object from DI and running it
                // 为了保证对象被释放，使用 ResolveAsDisposable 创建依赖项 
                // 在 using 代码块结束的时候自动调用 IocManager.Release 方法
                using (var tester = bootstrapper.IocManager.ResolveAsDisposable<Tester>())
                {
                    tester.Object.Run();
                } //Disposes tester and all it's dependencies

                Console.WriteLine("Press enter to exit...");
                Console.ReadLine();
            }
        }
    }
}
