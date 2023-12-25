using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UnitOfWork.EntityFramework;
using UnitOfWork;

namespace API.ServiceCollectionExtensions
{
    public static class UOWServiceCollectionExtentions
    {
        public static IServiceCollection AddUnitOfWork<TDbContext>(this IServiceCollection services) where TDbContext : DbContext
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<TDbContext>>();
            return services;
        }
    }
}
