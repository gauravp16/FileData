using Autofac;
using FileData.Queryables;

namespace FileData.Tests.Integration
{
    public class TestModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MockFileAttributeService>().AsImplementedInterfaces();
            builder.RegisterType<MockConfiguraionService>().AsImplementedInterfaces();
            builder.RegisterType<SizeQueryable>().As<FileAttribueQueryable>();
            builder.RegisterType<VersionQueryable>().As<FileAttribueQueryable>();
            builder.RegisterType<App>().AsSelf();
        }
    }
}
