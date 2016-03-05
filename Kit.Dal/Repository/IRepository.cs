namespace Kit.Dal.Repository
{
    public interface IRepository<in TKey, TEntity> 
        where TKey : struct 
        where TEntity : class
    {
        TEntity Find(TKey key);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}