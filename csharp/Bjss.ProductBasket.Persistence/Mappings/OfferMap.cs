namespace Bjss.ProductBasket.Persistence.Mappings
{
    using Core.Entities;
    using FluentNHibernate.Mapping;

    internal sealed class OfferMap : ClassMap<Offer>
    {
        public OfferMap()
        {
            Table("Offer");
            Id(offer => offer.Id).Not.Nullable().GeneratedBy.Identity();
            Map(offer => offer.Discount).Not.Nullable();
            References(offer => offer.Product).Not.LazyLoad().Column("ProductId");
            HasMany(offer => offer.Rules).Cascade.All().Not.LazyLoad();
        }
    }
}
