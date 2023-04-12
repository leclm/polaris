using Microsoft.EntityFrameworkCore;
using Polaris.Endereco.Context;
using System.Linq.Expressions;

namespace Polaris.Endereco.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        Task<T> GetByParameter(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        IQueryable<T> GetAllByParameter(Expression<Func<T, bool>> predicate);
        //void Delete(T entity);
    }
}

