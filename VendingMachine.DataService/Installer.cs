using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.RegistrationByConvention;

namespace VendingMachine.DataService
{
    /// <summary>
    /// Регистрация DataService
    /// </summary>
    public static class Installer
    {
        public static void Install(IUnityContainer container)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            Assembly dataService = assemblies.
                SingleOrDefault(assembly => assembly.GetName().Name == "VendingMachine.DataService");
            foreach (Type t in AllClasses.FromAssemblies(dataService)
                .Where(t => t.Name.EndsWith("Service") && t.Name != "BaseService"))
            {
                Type interfaceType = dataService.GetType("VendingMachine.DataService.Interface.I" + t.Name);

                IList<MethodInfo> mInfo = t.GetType().GetMethods().ToList();
                
                container.RegisterType(interfaceType, t);
            }
        }
    }
}
