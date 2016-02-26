using System;

namespace Kit.Kernel.UnitOfWork
{
    //[AttributeUsage(AttributeTargets.Method)]
    public class UnitOfWorkAttribute
    {
        public void Intercept(Action action)
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
            }*/
        }
    }
}