using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Autofac;


namespace UsingRefit_Client
{
    class Program
    {
        private AddClassWithoutRefit _addClassWithoutRefit;
        private AddClassWithRefit _addClassWithRefit;
        private IContainer _container;

        static void Main(string[] args)
        {
            Program p = new Program();
            p._container = p.BuildContainer().Build();
            p.Add();
        }

        private void Add()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                _addClassWithRefit = scope.Resolve<AddClassWithRefit>();
                _addClassWithoutRefit = scope.Resolve<AddClassWithoutRefit>();

                var result = _addClassWithoutRefit.Add(5, 10);
                Console.WriteLine("Without refit: " + result);
                Console.ReadLine();

                result = _addClassWithRefit.Add(5, 10);
                Console.WriteLine("With refit: " + result);
                Console.ReadLine();
            }
        }

        private ContainerBuilder BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AddClassWithRefit>().AsSelf();
            builder.RegisterType<AddClassWithoutRefit>().AsSelf();
            return builder;
        }
    }
}
