using System.Linq;

namespace Kit.Dal.Repository
{
    public interface IDbRepository<in TKey, TEntity> : IRepository<TKey, TEntity>
        where TKey : struct
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();
    }
}