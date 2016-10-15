namespace Bjss.ProductBasket.Persistence.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Entities;
    using Core.Repositories;
    using NHibernate;
    using NHibernate.Linq;

    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : Entity<TId>
    {
        private readonly ISession _session;

        protected ISession Session
        {
            get { return _session; }
        }

        protected Repository(ISession session)
        {
            _session = session;
        }

        public TEntity GetById(TId id)
        {
            return _session.Get<TEntity>(id);
        }

        public TEntity GetFirstBy(Func<TEntity, bool> expression)
        {
            return Session.Query<TEntity>().FirstOrDefault(expression);
        }

        public IReadOnlyList<TEntity> FindBy(Func<TEntity, bool> expression)
        {
            return Session.Query<TEntity>().Where(expression).ToList();
        }

        public void SaveOrUpdate(TEntity entity)
        {
            _session.SaveOrUpdate(entity);
        }

        public void Delete(TEntity entity)
        {
            _session.Delete(entity);
        }
    }
}
