namespace Bjss.ProductBasket.Core.Units
{
    using System.Text;
    using Extensions;

    public sealed class Bill
    {
        public decimal Total { get; internal set; }
        public decimal Subtotal { get; internal set; }
        public AppliedDiscounts AppliedDiscounts { get; private set; }

        public Bill() : this(0, 0, new AppliedDiscounts())
        {
        }

        public Bill(decimal subtotal, decimal total, AppliedDiscounts appliedDiscounts)
        {
            Total = total;
            Subtotal = subtotal;
            AppliedDiscounts = appliedDiscounts;
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine("Subtotal: " + Subtotal.ToBritainMoneyValueString());
            output.AppendLine(AppliedDiscounts.ToString());
            output.AppendLine("Total: " + Total.ToBritainMoneyValueString());

            return output.ToString();
        }
    }
}
