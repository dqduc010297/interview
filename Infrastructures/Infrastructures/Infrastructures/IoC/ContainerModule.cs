using Autofac;

namespace Infrastructures.IoC
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CoreApplicationModule>();
        }
    }
}
