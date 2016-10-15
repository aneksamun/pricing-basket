namespace Bjss.ProductBasket.Core.Sessions
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        void Rollback();
        void Commit();
    }
}
