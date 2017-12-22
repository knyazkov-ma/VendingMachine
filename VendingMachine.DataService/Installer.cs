using Unity;
using VendingMachine.DataService.Interface;

namespace VendingMachine.DataService
{
    /// <summary>
    /// Регистрация DataService
    /// </summary>
    public static class Installer
    {
        public static void Install(IUnityContainer container)
        {
            container.RegisterType<IOrderService, OrderService>();
        }
    }
}
