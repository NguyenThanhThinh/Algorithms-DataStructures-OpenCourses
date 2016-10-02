namespace _01.ProductsInPriceRange
{
    using System;

    public class ProductsTest
    {
        public static void Main()
        {
            var store = new ProductStore();

            store.Add("apples", 2.50M);
            store.Add("bananas", 1.20M);
            store.Add("milk", 1.33M);
            store.Add("water", 1.30M);
            store.Add("beer", 0.95M);
            store.Add("cheese", 8.5M);
            store.Add("muffin", 0.5M);

            store.EachProductInRange(0.95M, 2M, Console.WriteLine);
        }
    }
}
