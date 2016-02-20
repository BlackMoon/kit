using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using Kit.Dal.Repository;
using Kit.Kernel.UnitOfWork;

namespace Kit.Dal.UnitOfWork
{
    /// <summary>
    /// Unit of Work паттерн
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UnitOfWork<T> : IUnitOfWork, IDisposable where T : DataContext, new()
    {
        private bool _disposed;

        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public T Context { get; }

        public UnitOfWork(IDbConnection conn)
        {
            Context = new T();
        }


        /*public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            IRepository<TEntity> repo;

            Type type = typeof(TEntity);

            if (_repositories.ContainsKey(type))
                repo = (IRepository<TEntity>)_repositories[type];

            else
            {
                Type repositoryType = typeof(Repository<>);
                repo = (IRepository<TEntity>)Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), Context);

                _repositories.Add(type, repo);
            }

            return repo;
        }*/

        public void BeginTransaction()
        {
            
            throw new System.NotImplementedException();
        }

        public void Commit()
        {
            throw new System.NotImplementedException();
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
