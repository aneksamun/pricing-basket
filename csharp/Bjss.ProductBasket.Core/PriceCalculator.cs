namespace Bjss.ProductBasket.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using Entities;
    using Units;

    public static class PriceCalculator
    {
        public static Bill Calculate(IReadOnlyList<Product> products)
        {
            var bill = new Bill();

            foreach (var product in products)
            {
                bill.Subtotal += product.Price;
                bill.Total += product.Offers.Any() ? CalculateTotal(product, products, bill.AppliedDiscounts) : product.Price;
            }

            return bill;
        }

        private static decimal CalculateTotal(Product current, 
                                              IReadOnlyList<Product> others,
                                              AppliedDiscounts appliedDiscounts)
        {
            var amountToPay = current.Price;

            foreach (var offer in current.Offers)
            {
                if (!offer.Rules.Any())
                {
                    var appliedDiscount = AppliedDiscount.ApplyFor(current, offer);
                    amountToPay -= appliedDiscount.SavedAmount;
                    appliedDiscounts.Add(appliedDiscount);
                }
                else
                {
                    foreach (var rule in offer.Rules)
                    {
                        if (DoesRuleMatch(rule, others))
                        {
                            var appliedDiscount = AppliedDiscount.ApplyFor(current, offer);
                            amountToPay -= appliedDiscount.SavedAmount;
                            appliedDiscounts.Add(appliedDiscount);
                        }
                    }
                }
            }

            return amountToPay >= decimal.Zero ? amountToPay : decimal.Zero;
        }

        private static bool DoesRuleMatch(Rule rule, IReadOnlyList<Product> products)
        {
            var relatedProductsInBasket =
                products
                    .Where(product => product.Name == rule.RelatedProduct.Name)
                    .ToList();

            return relatedProductsInBasket.Count == rule.RelatedProductQuantity;
        }
    }
}
