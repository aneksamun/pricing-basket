namespace Bjss.ProductBasket.Desktop.Utils
{
    using Core;
    using Persistence.Factories;
    using Persistence.Setup;

    static class BasketBuilder
    {
        internal static Basket Build()
        {
            var databaseFileName = ConfigurationReader.GetDatabaseFileName();
            var sessionFactory = DatabaseInstaller.Setup(databaseFileName);
            var unitOfWorkFactory = new UnitOfWorkFactory(sessionFactory);
            var repositoryFactory = new RepositoryFactory();

            return new Basket(unitOfWorkFactory, repositoryFactory);
        }
    }
}
