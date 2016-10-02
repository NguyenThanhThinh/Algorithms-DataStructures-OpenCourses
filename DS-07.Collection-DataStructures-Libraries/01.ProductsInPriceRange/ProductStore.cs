namespace _01.ProductsInPriceRange
{
    using System;

    using Wintellect.PowerCollections;

    public class ProductStore
    {
        private readonly OrderedMultiDictionary<decimal, string> products;

        public ProductStore()
        {
            this.products = new OrderedMultiDictionary<decimal, string>(true);
        }

        public void Add(string name, decimal price)
        {
            this.products.Add(price, name);
        }

        public void EachProductInRange(decimal start, decimal end, Action<string> action)
        {
            var productsInRange = this.products.Range(start, true, end, true);
            foreach (var priceRange in productsInRange)
            {
                foreach (var item in priceRange.Value)
                {
                    action(string.Format("{0} {1}", item, priceRange.Key));
                }
            }
        }
    }
}
