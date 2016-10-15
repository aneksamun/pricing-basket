namespace Bjss.ProductBasket.Specs.Steps
{
    using System.Linq;
    using Core;
    using Core.Units;
    using Desktop.Utils;
    using NUnit.Framework;
    using TechTalk.SpecFlow;
    using TestObjects;

    [Binding]
    public class NoDiscountSteps
    {
        Bill _receivedBill;
        PricingItem[] _items; 

        [Given(@"I have added products with no offers")]
        public void GivenIHaveAddedProductsWithNoOffers(Table basket)
        {
            _items = basket.Rows.Select(row => new PricingItem(row[0], decimal.Parse(row[1]))).ToArray();
        }
        
        [When(@"I pricing items in basket")]
        public void WhenIPricingItemsInBasket()
        {
            using (var basket = BasketBuilder.Build())
            {
                var names = _items.Select(item => item.Name).ToArray();
                var products = basket.GetProducts(names);

                _receivedBill = PriceCalculator.Calculate(products);
            }
        }
        
        [Then(@"the normal price should be calculated")]
        public void ThenTheNormalPriceShouldBeCalculated()
        {
            var expectedSubtotal = _items.Sum(item => item.Price);
            var expectedTotal = expectedSubtotal;

            Assert.IsEmpty(_receivedBill.AppliedDiscounts);
            Assert.AreEqual(expectedTotal, _receivedBill.Total);
            Assert.AreEqual(expectedSubtotal, _receivedBill.Subtotal);
        }
    }
}
