namespace Bjss.ProductBasket.Persistence.Factories
{
    using System;
    using Core.Factories;
    using Core.Repositories;
    using Core.Sessions;
    using NHibernate;
    using Repositories;
    using Sessions;

    public sealed class RepositoryFactory : IRepositoryFactory
    {
        public IRuleRepository CreateForRule(IUnitOfWork unitOfWork)
        {
            return CreateRepository(session => new RuleRepository(session), unitOfWork);
        }

        public IOfferRepository CreateForOffer(IUnitOfWork unitOfWork)
        {
            return CreateRepository(session => new OfferRepository(session), unitOfWork);
        }

        public IProductRepository CreateForProduct(IUnitOfWork unitOfWork)
        {
            return CreateRepository(session => new ProductRepository(session), unitOfWork);
        }

        private static T CreateRepository<T>(Func<ISession, T> create, IUnitOfWork uow)
        {
            var session = ((UnitOfWork)uow).Session;
            return create(session);
        }
    }
}
