using DescubraOAssassino.Domain.Inferfaces.Repositories;
using DescubraOAssassino.Domain.Inferfaces.Repositories.Base;
using DescubraOAssassino.Domain.Inferfaces.Services;
using DescubraOAssassino.Domain.Services;
using DescubraOAssassino.Infra.Persistence;
using DescubraOAssassino.Infra.Persistence.Repositories;
using DescubraOAssassino.Infra.Persistence.Repositories.Base;
using DescubraOAssassino.Infra.Transactions;
using Microsoft.Practices.Unity;
using prmToolkit.NotificationPattern;
using System.Data.Entity;

namespace DescubraOAssassino.IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<DbContext, DescubraOAssassinoContext>(new HierarchicalLifetimeManager());
            //UnitOfWork
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            container.RegisterType<IServiceSuspeito, ServiceSuspeito>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceLocal, ServiceLocal>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceArma, ServiceArma>(new HierarchicalLifetimeManager());



            //Repository
            container.RegisterType(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

            container.RegisterType<IRepositorySuspeito, RepositorySuspeito>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryLocal, RepositoryLocal>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryArma, RepositoryArma>(new HierarchicalLifetimeManager());

        }
    }
}
