using System.Collections.Generic;

namespace Kit.Kernel.Repository
{
    public interface ICommonRepository<out TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
    }
}