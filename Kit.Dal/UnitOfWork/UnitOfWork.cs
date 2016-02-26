using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using Kit.Dal.Repository;
using Kit.Kernel.UnitOfWork;

namespace Kit.Dal.UnitOfWork
{
    /// <summary>
    /// Unit of Work паттерн
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UnitOfWork<T> : IUnitOfWork, IDisposable where T : DbContext, new()
    {
        private bool _disposed;

        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        private T Context { get; }

        public UnitOfWork(IDbConnection conn)
        {
            Context = new T();
        }


        public IDbRepository<TKey, TEntity> Repository<TKey, TEntity>() where TKey : struct where TEntity : class
        {
            IDbRepository<TKey, TEntity> repo = null;

            /*Type type = typeof(TEntity);

            if (_repositories.ContainsKey(type))
                repo = (IRepository<TEntity>)_repositories[type];

            else
            {
                Type repositoryType = typeof(Repository<>);
                repo = (IRepository<TEntity>)Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), Context);

                _repositories.Add(type, repo);
            }
            */
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
