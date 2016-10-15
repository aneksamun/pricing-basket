namespace Bjss.ProductBasket.Specs.Steps
{
    using System.Linq;
    using Core;
    using Core.Units;
    using Desktop.Utils;
    using NUnit.Framework;
    using TechTalk.SpecFlow;
    using TestObjects;
    using Utils;

    [Binding]
    public class SoapAndBreadDiscountSteps
    {
        Bill _receivedBill;
        PricingItem[] _items; 

        [Given(@"I have added products with special offer")]
        public void GivenIHaveAddedProductsWithSpecialOffer(Table basket)
        {
            _items = basket.Rows.Select(row => new PricingItem(row[0], decimal.Parse(row[1]))).ToArray();
        }
        
        [When(@"I buying items")]
        public void WhenIBuyingItems()
        {
            using (var basket = BasketBuilder.Build())
            {
                var names = _items.Select(item => item.Name).ToArray();
                var products = basket.GetProducts(names);

                _receivedBill = PriceCalculator.Calculate(products);
            }
        }

        [Then(@"the (.*) should be sold by half price")]
        public void ThenTheBreadShouldBeSoldByHalfPrice(string productName)
        {
            var expectedSubtotal = _items.Sum(item => item.Price);

            var productWithDiscount = _items.First(item => item.Name == productName);
            var savedAmount = PercentOffCalculator.Calculate(50, productWithDiscount.Price);
            var expectedTotal = expectedSubtotal - savedAmount;


            Assert.IsNotEmpty(_receivedBill.AppliedDiscounts);
            Assert.AreEqual(expectedTotal, _receivedBill.Total);
            Assert.AreEqual(expectedSubtotal, _receivedBill.Subtotal);
        }
    }
}
