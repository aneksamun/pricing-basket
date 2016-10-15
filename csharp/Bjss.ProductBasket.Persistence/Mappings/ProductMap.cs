namespace Bjss.ProductBasket.Persistence.Mappings
{
    using Core.Entities;
    using FluentNHibernate.Mapping;

    internal sealed class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Product");
            Id(product => product.Id).Not.Nullable().GeneratedBy.Identity();
            Map(product => product.Name).Not.Nullable();
            Map(product => product.Price).Not.Nullable().Precision(5).Scale(2);
            HasMany(product => product.Offers).Cascade.All().Not.LazyLoad();
        }
    }
}
