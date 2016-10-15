namespace Bjss.ProductBasket.Core.Entities
{
    public class Rule : Entity<int>
    {
        public virtual Offer Offer { get; set; }
        public virtual Product RelatedProduct { get; set; }
        public virtual int RelatedProductQuantity { get; set; }
    }
}
