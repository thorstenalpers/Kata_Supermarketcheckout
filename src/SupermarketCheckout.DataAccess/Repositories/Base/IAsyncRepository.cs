namespace SupermarketCheckout.DataAccess.Repositories.Base
{
    using SupermarketCheckout.DataAccess.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
