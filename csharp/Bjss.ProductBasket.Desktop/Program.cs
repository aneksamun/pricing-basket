namespace Bjss.ProductBasket.Desktop
{
    using System;
    using System.Linq;
    using Core;
    using Utils;

    public class Program
    {
        public static void Main(string[] args)
        {
            if (!args.Any())
            {
                Console.WriteLine("No items found in basket.");
                Console.WriteLine("Usage: ProductBasket [Item1] [Item2] ... [ItemN]");
                Console.ReadLine();
                return;
            }

            using (var basket = BasketBuilder.Build())
            {
                var products = basket.GetProducts(args);

                if (!products.Any())
                {
                    Console.WriteLine("No matching products found.");
                    Console.ReadLine();
                    return;
                }

                var excludedArguments = basket.GetExcluded(args, products);
                foreach (var argument in excludedArguments)
                    Console.WriteLine("The '{0}' excluded", argument);

                var bill = PriceCalculator.Calculate(products);
                Console.WriteLine(bill);

                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }
        }
    }
}
