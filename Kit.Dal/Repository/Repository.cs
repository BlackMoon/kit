using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Kit.Dal.Repository
{
    public class Repository<TEntity> : IDbRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _ctx;

        private IDbSet<TEntity> _entities;

        private IDbSet<TEntity> Entities => _entities = _entities ?? _ctx.Set<TEntity>();

        public Repository(DbContext ctx)
        {
            _ctx = ctx;
            
        }

        public void Add(TEntity entity)
        {
            _ctx.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _ctx.Set<TEntity>().Remove(entity);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _ctx.Set<TEntity>().FirstOrDefault(predicate);
        }

        public virtual TEntity FindByKey<TKey>(TKey key) where TKey : struct
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities;
        }
    }
}
