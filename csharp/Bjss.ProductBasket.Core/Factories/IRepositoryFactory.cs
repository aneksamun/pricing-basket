namespace Bjss.ProductBasket.Core.Factories
{
    using Repositories;
    using Sessions;

    public interface IRepositoryFactory
    {
        IRuleRepository CreateForRule(IUnitOfWork unitOfWork);
        IOfferRepository CreateForOffer(IUnitOfWork unitOfWork);
        IProductRepository CreateForProduct(IUnitOfWork unitOfWork);
    }
}
