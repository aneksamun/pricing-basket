namespace Bjss.ProductBasket.Core.Factories
{
    using System;
    using Sessions;

    public interface IUnitOfWorkFactory : IDisposable
    {
        IUnitOfWork Create();
    }
}
