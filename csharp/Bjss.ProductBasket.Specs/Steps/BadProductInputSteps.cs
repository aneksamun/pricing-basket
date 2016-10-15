namespace Bjss.ProductBasket.Specs.Steps
{
    using System.Linq;
    using Desktop.Utils;
    using NUnit.Framework;
    using TechTalk.SpecFlow;
    using Table = TechTalk.SpecFlow.Table;

    [Binding]
    public class BadProductInputSteps
    {
        string[] _origin;
        string[] _excluded;

        [Given(@"I have defined none existing products")]
        public void GivenIHaveDefinedNoneExistingProducts(Table table)
        {
            _origin = table.Rows.Select(row => row[0]).ToArray();
        }
        
        [When(@"I do pricing")]
        public void WhenIDoPricing()
        {
            using (var basket = BasketBuilder.Build())
            {
                var products = basket.GetProducts(_origin);
                _excluded = basket.GetExcluded(_origin, products);
            }
        }
        
        [Then(@"the items should be excluded")]
        public void ThenTheItemsShouldBeExcluded()
        {
            Assert.IsTrue(_origin.All(origin => _excluded.Contains(origin)));
        }
    }
}
