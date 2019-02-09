namespace SupermarketCheckout.DataAccess.Repositories.Base
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SupermarketCheckout.DataAccess.Models;

    public abstract class EfRepository<T> : IRepository<T>, IAsyncRepository<T> where T : BaseEntity
    {
        protected DbContext DbContext { get; set; }

        protected EfRepository(DbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public virtual T GetById(int id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await DbContext.Set<T>().FindAsync(id).ConfigureAwait(false);
        }

        public virtual IEnumerable<T> ListAll()
        {
            return DbContext.Set<T>().AsEnumerable();
        }

        public virtual async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await DbContext.Set<T>().ToListAsync().ConfigureAwait(false);
        }

        public virtual T Add(T entity)
        {
            DbContext.Set<T>().Add(entity);
            DbContext.SaveChanges();

            return entity;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            DbContext.Set<T>().Add(entity);
            await DbContext.SaveChangesAsync().ConfigureAwait(false);

            return entity;
        }

        public virtual void Update(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            DbContext.SaveChanges();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
