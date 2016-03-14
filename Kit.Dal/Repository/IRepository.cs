using System;

namespace Kit.Dal.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Find(Predicate<TEntity> predicate);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}