using System;
using CacheLibrary;

    public class CacheHandler
    {
        public static ICache cache;

        public static void initializeCache()
        {
            cache = new CacheClient("127.0.0.1", 5000, "products");
            cache.Initialize();
        }

        public static void addProduct()
        {
            Product sampleProduct = new Product
            {
                Id = 1,
                Name = "Sample Product",
                Price = 99.99m,
                Description = "This is a sample product."
            };

            cache.Add("product:2", sampleProduct);
        }
        public static void getProduct(){

            // Use the generic Get method for type-safe deserialization.
            Product retrievedProduct = cache.Get<Product>("product:2");

            if (retrievedProduct != null)
            {
                Console.WriteLine("Retrieved Product:");
                Console.WriteLine($"ID: {retrievedProduct.Id}");
                Console.WriteLine($"Name: {retrievedProduct.Name}");
                Console.WriteLine($"Price: {retrievedProduct.Price}");
                Console.WriteLine($"Description: {retrievedProduct.Description}");
            }
            else
            {
                Console.WriteLine("Product not found in cache.");
            }
            cache.Dispose();
        }
    }

