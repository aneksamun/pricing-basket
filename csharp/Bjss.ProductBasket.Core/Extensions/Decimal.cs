namespace Bjss.ProductBasket.Core.Extensions
{
    internal static class DecimalExtensions
    {
        internal static string ToBritainMoneyValueString(this decimal amount)
        {
            var pattern = amount >= 1 ? "£{0}" : "{0}p";
            return pattern.FormatWith(amount.ToString("0.00"));
        }
    }
}
