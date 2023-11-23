using System;
using Autofac;

namespace ERP.Core.ExtensionMethods
{
        public static class myServices
        {
            public static void RegisterServices(ContainerBuilder builder)
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();

                foreach (var assembly in assemblies)
                {
                    var serviceTypes = assembly.GetTypes()
                        .Where(type => type.IsClass && !type.IsAbstract && type.GetInterfaces().Any() &&
                            !typeof(System.Runtime.Serialization.ISerializable).IsAssignableFrom(type));

                    foreach (var serviceType in serviceTypes)
                    {
                        var interfaces = serviceType.GetInterfaces();

                        foreach (var serviceInterface in interfaces)
                        {
                            builder.RegisterType(serviceType).As(serviceInterface).InstancePerLifetimeScope();
                        }
                    }
                }
            }
        }
    
}
