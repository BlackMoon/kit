using Kit.Dal.Repository;

namespace Kit.Dal.UnitOfWork
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Opens database connection and begins transaction.
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Commits transaction and closes database connection.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollbacks transaction and closes database connection.
        /// </summary>
        void Rollback();

        IDbRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}