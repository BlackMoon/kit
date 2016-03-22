using System;
using System.Linq.Expressions;

namespace Kit.Kernel.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}