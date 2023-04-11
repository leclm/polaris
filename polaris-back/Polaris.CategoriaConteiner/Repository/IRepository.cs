using System.Linq.Expressions;

namespace Polaris.CategoriaConteiner.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        Task<T> GetByParameter(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetAllByParameter(Expression<Func<T, bool>> predicate);
    }
}
