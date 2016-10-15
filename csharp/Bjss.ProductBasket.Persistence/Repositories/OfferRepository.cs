namespace Bjss.ProductBasket.Persistence.Repositories
{
    using Core.Entities;
    using Core.Repositories;
    using NHibernate;

    public sealed class OfferRepository : Repository<Offer, int>, IOfferRepository
    {
        public OfferRepository(ISession session) 
            : base(session)
        {
        }
    }
}
