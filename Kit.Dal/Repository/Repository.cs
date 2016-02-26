using System.Data.Entity;
using System.Linq;

namespace Kit.Dal.Repository
{
    public class Repository<TKey, TEntity> : IDbRepository<TKey, TEntity>
        where TKey : struct
        where TEntity : class
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

        public TEntity Find(TKey key)
        {
            return _ctx.Set<TEntity>().Find(key);
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
