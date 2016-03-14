using System.Linq;

namespace Kit.Dal.Repository
{
    public interface IDbRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
    }
}