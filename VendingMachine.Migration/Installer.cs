using Unity;
using Unity.Injection;

namespace VendingMachine.Migration
{
    public class Installer
    {
        public static void Install(IUnityContainer container, string connectionString)
        {

            container.RegisterType<IMigrationRunner, MigrationRunner>(new InjectionConstructor(connectionString));
        }
    }
}
