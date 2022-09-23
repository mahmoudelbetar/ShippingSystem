using System.Linq.Expressions;

namespace ShippingSystem.Interfaces
{
    public interface IRepository<T> where T : class
    {
        
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includePropertis = null);
        Task<IEnumerable<T>> GetAll(string? includePropertis = null);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter, string? includePropertis = null);
        void Add(T entity);
        Task<T> GetById(int id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
