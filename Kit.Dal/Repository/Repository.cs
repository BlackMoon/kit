using System;
using System.Data.Entity;
using System.Linq;

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

        public TEntity Find(Predicate<TEntity> predicate)
        {
            return _ctx.Set<TEntity>().Find(predicate);
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
