namespace Bjss.ProductBasket.Specs.Utils
{
    internal static class PercentOffCalculator
    {
        internal static decimal Calculate(int discount, decimal price)
        {
            var amount = discount * price / 100;
            return decimal.Round(amount, 2);
        }
    }
}
