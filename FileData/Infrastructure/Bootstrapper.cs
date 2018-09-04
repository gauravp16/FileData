using System;
using Autofac;
using FileData.Services;
using log4net;
using ThirdPartyTools;

namespace FileData.Infrastructure
{
    /// <summary>
    /// Responsible for initialising the app.
    /// </summary>
    public class Bootstrapper
    {
        private readonly static ILog Log = LogManager.GetLogger(typeof(Bootstrapper));

        public static bool Initialize(out App app)
        {
            app = null;

            try
            {
                if (!ConfigureLogging())
                    return false;

                var container = InitialiseContainer();
                if (container == null)
                    return false;

                app = container.Resolve<App>();
                return true;
            }
            catch(Exception ex)
            {
                //log actual error
                Log.Error("Error while starting the app", ex);
                return false;
            }
        }

        private static bool ConfigureLogging()
        {
            log4net.Config.XmlConfigurator.Configure();
            return true;
        }

        private static IContainer InitialiseContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileAttributeService>().AsImplementedInterfaces();
            builder.RegisterType<ConfigurationService>().AsImplementedInterfaces();
            builder.RegisterType<SizeQueryable>().As<FileAttribueQueryable>();
            builder.RegisterType<VersionQueryable>().As<FileAttribueQueryable>();
            builder.RegisterType<FileDetails>().AsSelf();
            builder.RegisterType<App>().AsSelf();

            return builder.Build();
        }

        private static object ConfigurationService()
        {
            throw new NotImplementedException();
        }
    }
}
