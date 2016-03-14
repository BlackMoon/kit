using System;
using System.Collections.Generic;
using System.Data.Entity;
using Kit.Dal.Repository;

namespace Kit.Dal.UnitOfWork
{
    /// <summary>
    /// Unit of Work паттерн
    /// </summary>
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private const string Namespace = "Kit.Dal.Repository";

        private bool _disposed;

        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        private DbContext Context { get; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public IDbRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            IDbRepository<TEntity> repo;

            Type type = typeof(TEntity);

            if (_repositories.ContainsKey(type))
                repo = (IDbRepository<TEntity>)_repositories[type];
            
            else
            {
                Type repositoryType = Type.GetType($"{Namespace}.{type.Name}Repository");
                repo = (repositoryType != null) ? 
                    (IDbRepository<TEntity>)Activator.CreateInstance(repositoryType, Context) : 
                    new Repository<TEntity>(Context);

                _repositories.Add(type, repo);
            }
            
            return repo;
        }

        public void BeginTransaction()
        {
            
            throw new System.NotImplementedException();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Rollback()
        {
            throw new System.NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    Context.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
