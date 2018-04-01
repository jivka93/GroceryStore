using DAL.Contracts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAL
{
    public class EfGenericRepository<T> : IEfGenericRepository<T> where T : class
    {

        public EfGenericRepository(GroceryStoreContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected GroceryStoreContext Context { get; private set; }
        protected DbSet<T> DbSet { get; private set; }


        public IQueryable<T> All
        {
            get
            {
                return this.DbSet;
            }
        }

        public void Add(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Added;               
        }

        public void Add(ICollection<T> entities)
        {
            foreach (var e in entities)
            {
                var entry = this.Context.Entry(e);
                entry.State = EntityState.Added;
            }
        }

        public void AddOrUpdate(T entity)
        {
            this.Context.Set<T>().AddOrUpdate(entity);
        }

        public void Delete(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public void Update(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
