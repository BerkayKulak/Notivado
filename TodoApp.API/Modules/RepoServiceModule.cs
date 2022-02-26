using System.Reflection;
using Autofac;
using TodoApp.Core.Repositories;
using TodoApp.Core.Services;
using TodoApp.Core.UnitOfWorks;
using TodoApp.Repository;
using TodoApp.Repository.Repositories;
using TodoApp.Repository.UnitOfWorks;
using TodoApp.Service.Mapping;
using TodoApp.Service.Services;
using Module = Autofac.Module;

namespace TodoApp.API.Modules
{
    public class RepoServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(ServiceGeneric<,>)).As(typeof(IServiceGeneric<,>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            // burda aslında class adı farketmez
            // buralarda hangi katmana bakacağız onu söylüyoruz class olarak o katmandan bir class okey bizim için
            var serviceAssembly = Assembly.GetAssembly(typeof(DtoMapper));
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

        }
    }
}
