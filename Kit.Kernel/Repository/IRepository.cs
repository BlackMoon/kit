using System;
using System.Linq.Expressions;

namespace Kit.Kernel.Repository
{
    /// <summary>
    /// Интерфейс репозиторий
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}