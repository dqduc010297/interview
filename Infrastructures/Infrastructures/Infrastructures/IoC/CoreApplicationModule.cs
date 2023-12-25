using Autofac;
using Domain.Entities;
using UnitOfWork;

namespace Infrastructures.IoC
{
    public class CoreApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = GetSolutionAssemblies();
             
            // Register repositories
            builder.RegisterAssemblyTypes(assemblies)
                .AssignableTo<IRepository>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }

        private static System.Reflection.Assembly[] GetSolutionAssemblies()
        {
            var entryAssembly = System.Reflection.Assembly.GetEntryAssembly();
            var assembliesList = new List<System.Reflection.Assembly>
            {
                entryAssembly
            };
            assembliesList.AddRange(entryAssembly.GetReferencedAssemblies()
                                                 .Where(x => x.FullName.StartsWith(""))
                                                 .Select(System.Reflection.Assembly.Load));
            return assembliesList.ToArray();
        }
    }
}
