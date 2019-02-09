namespace SupermarketCheckout.DataAccess.Repositories.Base
{
    using System.Collections.Generic;
    using SupermarketCheckout.DataAccess.Models;

    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        IEnumerable<T> ListAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
