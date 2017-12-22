using VendingMachine.Data.Repository;
using VendingMachine.Entity;
using Unity;

namespace VendingMachine.Data.NHibernate.Repository
{
    public static class Installer
    {
        public static void Install(IUnityContainer container)
        {
           
            container.RegisterType<IBaseRepository<Product>, BaseRepository<Product>>();
            container.RegisterType<IBaseRepository<Combination>, BaseRepository<Combination>>();
            container.RegisterType<IBaseRepository<Composition>, BaseRepository<Composition>>();
        }
        
    }
}
