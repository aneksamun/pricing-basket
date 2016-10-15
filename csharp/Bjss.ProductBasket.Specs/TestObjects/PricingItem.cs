namespace Bjss.ProductBasket.Specs.TestObjects
{
    public class PricingItem
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public PricingItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
