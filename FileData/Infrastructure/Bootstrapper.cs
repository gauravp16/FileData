using System;
using Autofac;
using log4net;

namespace FileData.Infrastructure
{
    /// <summary>
    /// Responsible for initialising the app.
    /// </summary>
    public class Bootstrapper
    {
        private readonly static ILog Log = LogManager.GetLogger(typeof(Bootstrapper));

        public static bool Init(out App app)
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

            builder.RegisterModule(new FileDataModule());
            return builder.Build();
        }
    }
}
