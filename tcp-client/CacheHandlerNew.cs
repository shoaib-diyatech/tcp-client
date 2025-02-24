using System;
using CacheLibrary;
using log4net;
using log4net.Config;

public class CacheHandlerNew
{
    private const string Key = "product:111";
    public static readonly ILog log = LogManager.GetLogger(typeof(CacheHandler));
    public static ICache cache;

    public static void initializeCache()
    {

        // cache = new CacheClient("127.0.0.1", 5000, "products");
        //cache = new CacheClient(Program.IP, Program.PORT, "products");
        cache = new CacheImplementation(Program.IP, Program.PORT, "products");

        cache.Initialize();
        log.Info("Cache Initialized.");
    }

    public static void addProduct()
    {
        Product sampleProduct = new Product
        {
            Id = 4445,
            Name = "Sample Product",
            Price = 99.99m,
            Description = "This is a sample product."
        };

        cache.Add(Key, sampleProduct);
        Console.WriteLine($"Product: {Key} Added in cache");
    }
    public static Product getProduct()
    {

        // Use the generic Get method for type-safe deserialization.
        //Product retrievedProduct = cache.Get<Product>(Key);
        Product retrievedProduct = (Product)cache.Get(Key);  
        if (retrievedProduct != null)
        {
            Console.WriteLine("Retrieved Product:");
            Console.WriteLine($"ID: {retrievedProduct.Id}");
            Console.WriteLine($"Name: {retrievedProduct.Name}");
            Console.WriteLine($"Price: {retrievedProduct.Price}");
            Console.WriteLine($"Description: {retrievedProduct.Description}");
            return retrievedProduct;
        }
        else
        {
            Console.WriteLine("Product not found in cache.");
            return null;
        }
        cache.Dispose();
    }
    public static void addRandomProduct()
    {
        int id = new Random().Next(1, 10000);
        Product randomProduct = new Product
        {
            Id = id,
            Name = $"Random Product {id}",
            Price = (decimal)new Random().NextDouble() * 100,
            Description = $"This is a random product with ID {id}."
        };
        cache.Add($"product:{id}", randomProduct);
    }
}

