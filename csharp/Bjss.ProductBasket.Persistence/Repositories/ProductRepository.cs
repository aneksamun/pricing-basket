namespace Bjss.ProductBasket.Persistence.Repositories
{
    using Core.Entities;
    using Core.Repositories;
    using NHibernate;

    public sealed class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(ISession session)
            : base(session)
        {
        }
    }
}
