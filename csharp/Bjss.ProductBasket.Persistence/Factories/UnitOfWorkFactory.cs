namespace Bjss.ProductBasket.Persistence.Factories
{
    using System;
    using Core.Factories;
    using Core.Sessions;
    using NHibernate;
    using Sessions;

    public sealed class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private bool _isDisposed;
        private readonly ISessionFactory _factory;

        public UnitOfWorkFactory(ISessionFactory factory)
        {
            _factory = factory;
        }

        ~UnitOfWorkFactory()
        {
            Dispose(false);
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(_factory.OpenSession());
        }

        private void Dispose(bool disposing)
        {
            if (_isDisposed) return;
            if (disposing) _factory.Dispose();
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
