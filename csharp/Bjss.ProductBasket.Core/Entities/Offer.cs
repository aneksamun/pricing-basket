namespace Bjss.ProductBasket.Core.Entities
{
    using System.Collections.Generic;

    public class Offer : Entity<int>
    {
        public virtual int Discount { get; set; }
        public virtual Product Product { get; set; }
        public virtual ISet<Rule> Rules { get; set; }
    }
}
