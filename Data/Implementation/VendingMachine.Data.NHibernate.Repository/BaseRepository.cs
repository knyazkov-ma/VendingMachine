using VendingMachine.Data.Repository;
using VendingMachine.Entity;
using NHibernate;
using System.Linq;
using System;


namespace VendingMachine.Data.NHibernate.Repository
{
    public class BaseRepository 
    {

        protected readonly ISession session;


        public BaseRepository(ISession session)
        {
            this.session = session;
        }

    }

    public class BaseRepository<T> : BaseRepository, IBaseRepository<T>
        where T : BaseEntity
    {

        public BaseRepository(ISession session)
            : base(session)
        {

        }

        public virtual IQueryable<T> GetList()
        {
            return session.Query<T>();
        }

        

        public virtual IQueryable<T> GetList(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return session.Query<T>().Where(predicate);
        }
        

        public virtual T Get(long id)
        {
            return session.Query<T>().FirstOrDefault(t => t.Id == id);
        }
        
        public virtual T Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return session.Query<T>().FirstOrDefault(predicate);
        }
       
    }
}
