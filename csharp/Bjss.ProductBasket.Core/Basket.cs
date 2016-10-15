namespace Bjss.ProductBasket.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Entities;
    using Factories;

    public sealed class Basket : IDisposable
    {
        private bool _isDisposed;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IRepositoryFactory _repositoryFactory;

        public Basket(IUnitOfWorkFactory unitOfWorkFactory, IRepositoryFactory repositoryFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _repositoryFactory = repositoryFactory;
        }

        ~Basket()
        {
            Dispose(false);
        }

        public IReadOnlyList<Product> GetProducts(string[] names)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var repository = _repositoryFactory.CreateForProduct(uow);

                var products = 
                    names
                        .Select(name => repository.GetFirstBy(entity => string.Equals(entity.Name, name, StringComparison.CurrentCultureIgnoreCase)))
                        .Where(product => product != null);

                return products.ToList();
            }
        }

        public string[] GetExcluded(string[] names, IReadOnlyList<Product> products)
        {
            var existingProductNames = 
                products
                    .Select(product => product.Name.ToLower())
                    .ToList();

            return names.Where(name => !existingProductNames.Contains(name.ToLower())).ToArray();
        }

        public void AddProducts(IEnumerable<Product> products)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var repository = _repositoryFactory.CreateForProduct(uow);

                try
                {
                    foreach (var product in products)
                        repository.SaveOrUpdate(product);
                    uow.Commit();
                }
                catch (Exception)
                {
                    uow.Rollback();
                    throw;
                }
            }
        }

        private void Dispose(bool disposing)
        {
            if (_isDisposed) return;
            if (disposing) _unitOfWorkFactory.Dispose();
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
