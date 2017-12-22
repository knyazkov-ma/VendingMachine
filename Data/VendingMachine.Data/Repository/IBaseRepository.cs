using VendingMachine.Entity;
using System.Linq;
using System.Linq.Expressions;
using System;


namespace VendingMachine.Data.Repository
{
    /// <summary>
    /// Общий для всех репозиториев интерфейс
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetList();
                
        IQueryable<T> GetList(Expression<Func<T, bool>> predicate);
      
        T Get(Expression<Func<T, bool>> predicate);
        
    }
}
