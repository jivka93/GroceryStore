using System.Collections.Generic;
using System.Linq;

namespace DAL.Contracts
{
    public interface IEfGenericRepository<T> where T : class
    {
        IQueryable<T> All { get; }

        T GetById(object id);

        void Add(T entity);

        void Add(ICollection<T> entities);

        void Delete(T entity);

        void Update(T entity);

        void AddOrUpdate(T entity);
    }
}
