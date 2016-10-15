namespace Bjss.ProductBasket.Persistence.Mappings
{
    using Core.Entities;
    using FluentNHibernate.Mapping;

    internal sealed class RuleMap : ClassMap<Rule>
    {
        public RuleMap()
        {
            Table("Rule");
            Id(rule => rule.Id).Not.Nullable().GeneratedBy.Identity();
            Map(rule => rule.RelatedProductQuantity).Not.Nullable();
            References(rule => rule.Offer).Not.LazyLoad().Column("OfferId");
            References(rule => rule.RelatedProduct).Not.LazyLoad().Column("RelatedProductId");
        }
    }
}
