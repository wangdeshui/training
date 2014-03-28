using System;
using System.IO;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Foundation.Plugin;

namespace Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            var windsorContainer = new WindsorContainer();
            windsorContainer.Register(
                Component.For<PluginManager>()
                         .UsingFactoryMethod(ken => new PluginManager(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins")))
                         .LifestyleSingleton(),
                Component.For<PlanService>()
                         .LifestyleSingleton()
            );

            var planService = windsorContainer.Resolve<PlanService>();

            foreach (var name in planService.GetAvailableAlgorithmNames())
            {
                Console.WriteLine("Plugin: {0}", name);
            }

            Console.Read();
        }
    }
}
