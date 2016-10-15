namespace Bjss.ProductBasket.Core.Units
{
    using Entities;
    using Extensions;

    public sealed class AppliedDiscount
    {
        private readonly int _percentOff;
        private readonly string _productName;
        private readonly decimal _savedAmount;

        private AppliedDiscount(int percentOff,
                                string productName,
                                decimal savedAmount)
        {
            _productName = productName;
            _percentOff = percentOff;
            _savedAmount = savedAmount;
        }

        public string ProductName
        {
            get { return _productName; }
        }

        public int PercentOff
        {
            get { return _percentOff; }
        }

        public decimal SavedAmount
        {
            get { return _savedAmount; }
        }

        public override string ToString()
        {
            return "{0} {1}% off: {2}".FormatWith(ProductName, PercentOff, SavedAmount.ToBritainMoneyValueString());
        }

        internal static AppliedDiscount ApplyFor(Product product, Offer offer)
        {
            var savedAmount = CalculateDiscount(offer.Discount, product.Price);
            return new AppliedDiscount(offer.Discount, product.Name, savedAmount);
        }

        private static decimal CalculateDiscount(int percentOffRate, decimal price)
        {
            var amount = percentOffRate * price / 100;
            return decimal.Round(amount, 2);
        }
    }
}
