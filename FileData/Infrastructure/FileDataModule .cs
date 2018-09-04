using Autofac;
using FileData.Queryables;
using FileData.Services;
using ThirdPartyTools;

namespace FileData.Infrastructure
{
    public class FileDataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileAttributeService>().AsImplementedInterfaces();
            builder.RegisterType<ConfigurationService>().AsImplementedInterfaces();
            builder.RegisterType<SizeQueryable>().As<FileAttribueQueryable>();
            builder.RegisterType<VersionQueryable>().As<FileAttribueQueryable>();
            builder.RegisterType<FileDetails>().AsSelf();
            builder.RegisterType<App>().AsSelf();
        }
    }
}
