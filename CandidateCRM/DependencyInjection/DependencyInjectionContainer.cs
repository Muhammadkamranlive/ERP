using Autofac;
using ERP.Common.Services;
using ERP.Core.ServiceAccess;
using ERP.Core.BusinessAccess;
using CRM.Authentication.Repository;

namespace CandidateCRM.DependencyInjection
{
    public class DependencyInjectionContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repo<>)).As(typeof(IRepo<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Base_Service<>)).As(typeof(IBase_Service<>)).InstancePerLifetimeScope();
            

        }
    }
    
}
