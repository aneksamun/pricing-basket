namespace Bjss.ProductBasket.Persistence.Sessions
{
    using System;
    using System.Data;
    using Core.Sessions;
    using NHibernate;

    public class UnitOfWork : IUnitOfWork
    {
        private bool _isDisposed;
        private readonly ISession _session;
        private readonly ITransaction _transaction;

        public ISession Session
        {
            get { return _session; }
        }

        public UnitOfWork(ISession session)
        {
            _session = session;
            _transaction = _session.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public void Rollback()
        {
            if (_transaction.IsActive)
                _transaction.Rollback();
        }

        public void Commit()
        {
            if (_transaction.IsActive)
                _transaction.Commit();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;

            if (disposing)
            {
                _transaction.Dispose();
                _session.Dispose();
            }

            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
