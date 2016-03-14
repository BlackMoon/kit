using System;
using PostSharp.Aspects;

namespace Kit.Kernel.UnitOfWork
{
    [Serializable]
    public class UnitOfWorkAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            
        }

        /*public void Intercept(Action action)
        {
            /*IUnitOfWork _uow = UoWUtils.UoWFactory();
            if (_uow.IsInTransaction())//Если транзакция уже запущена или не требуется, просто вызываем метод
            {
                action();
                return;
            }

            _uow.BeginTransaction();
            try
            {
                action();
                _uow.Commit();
            }
            catch
            {
                _uow.Rollback();
                throw;
            }
        }*/
    }
}