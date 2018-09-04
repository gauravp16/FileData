using System;
using Autofac;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var container = InitialiseContainer();

            var app = container.Resolve<App>();
            var result = app.Query(args[1], args[0]);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static IContainer InitialiseContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileAttributeService>().AsImplementedInterfaces();
            builder.RegisterType<SizeQueryable>().As<FileAttribueQueryable>();
            builder.RegisterType<VersionQueryable>().As<FileAttribueQueryable>();
            builder.RegisterType<FileDetails>().AsSelf();
            builder.RegisterType<App>().AsSelf();

            return builder.Build();
        }
    }
}
