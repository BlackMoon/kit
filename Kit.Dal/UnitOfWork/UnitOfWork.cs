using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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

        private DbTransaction Transaction { get; set; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public IDbRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            object repo;

            Type type = typeof(TEntity);

            if (_repositories.ContainsKey(type))
                repo = _repositories[type];
            
            else
            {
                Type repositoryType = Type.GetType($"{Namespace}.{type.Name}Repository");
                repo = (repositoryType != null) ? 
                    Activator.CreateInstance(repositoryType, Context) : 
                    new Repository<TEntity>(Context);

                _repositories.Add(type, repo);
            }
            
            return (IDbRepository<TEntity>)repo;
        }

        public void BeginTransaction()
        {
            Transaction = Context.Database.BeginTransaction().UnderlyingTransaction;
        }

        public void Commit()
        {
            try
            {
                Context.Database.UseTransaction(Transaction);
                Context.SaveChanges();
                Transaction?.Commit();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
            
        }

        public void Rollback()
        {
            Transaction?.Rollback();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                    Transaction?.Dispose();
                }
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
