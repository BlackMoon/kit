using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using Kit.Kernel.UnitOfWork;

namespace Kit.Dal.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork, IDisposable where T : DataContext
    {
        private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public T Context { get; private set; }

        public UnitOfWork(IDbConnection conn)
        {
            //Context = context;
        }

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

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
