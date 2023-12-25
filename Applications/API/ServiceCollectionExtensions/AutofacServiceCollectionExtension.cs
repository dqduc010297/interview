using Autofac;
using Autofac.Extensions.DependencyInjection;
using Infrastructures.IoC;

namespace API.ServiceCollectionExtensions
{
    public static class AutofacServiceCollectionExtension
    {
        public static WebApplicationBuilder AddAutofac(this WebApplicationBuilder builder)
        {
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new ContainerModule()));

            return builder;
        }
    }
}
