using System.Linq.Expressions;

namespace ERP.Core.ServiceAccess
{
    public interface IBase_Service<T> where T : class
    {
        Task<T?> Get(Guid id);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Delete(Guid id);
        Task InsertAsync(T entity);
        void UpdateRecord(T entity);
        Task<int> CompleteAync();

    }
}
