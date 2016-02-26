using System.Collections.Generic;

namespace Kit.Dal.Repository
{
    public interface ICommonRepository<in TKey, TEntity> : IRepository<TKey, TEntity> 
        where TKey : struct 
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
    }
}