using NHibernate;
using Unity;
using Unity.Lifetime;
using Unity.Injection;

namespace VendingMachine.Data.NHibernate
{
    public static class Installer
    {
        public static void Install(IUnityContainer container, LifetimeManager lifetimeManager)
        {
            //регистрация ISession
            container.RegisterType<ISession>(new InjectionFactory(c => NHibernateSessionManager.Instance.GetSession()));
            container.RegisterType<ISession>(lifetimeManager);
       
        }
    }
}
