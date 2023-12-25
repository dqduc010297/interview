using System.Reflection;

namespace API.ServiceCollectionExtensions
{
    public static class MediatRServiceCollectionExtension
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(
                cfg => cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(Domains.AssemplyMarker)))); 
            return services;
        }
    }
}
