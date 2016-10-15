namespace Bjss.ProductBasket.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using Entities;

    public interface IRepository<TEntity, in TId>
        where TEntity : Entity<TId>
    {
        TEntity GetById(TId id);
        TEntity GetFirstBy(Func<TEntity, bool> expression);
        IReadOnlyList<TEntity> FindBy(Func<TEntity, bool> expression);
        void SaveOrUpdate(TEntity entity);
        void Delete(TEntity entity);
    }
}
