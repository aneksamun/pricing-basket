namespace Bjss.ProductBasket.Core.Entities
{
    using System.Collections.Generic;

    public class Product : Entity<int>
    {
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
        public virtual ISet<Offer> Offers { get; set; }
    }
}
