using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System.Configuration;

class Program
{
    public static readonly ILog log = LogManager.GetLogger(typeof(TcpClient));

    public static string IP;

    public static int PORT;
    static async Task Main()
    {
        Console.WriteLine("Client App Started.");
        ConfigureLogging();
        log.Info("Client App Started.");
        string port = ConfigurationManager.AppSettings["port"] ?? "8080";
        int.TryParse(port, out PORT);
        string ip = ConfigurationManager.AppSettings["ip"] ?? "127.0.0.1";
        IP = ip;
        Console.WriteLine($"Connecting to TCP-SERVER on IP: [{ip}], Port: [{port}]");
        log.Info($"Connecting to TCP-SERVER on IP: [{ip}], Port: [{port}]");

        try
        {
            CacheHandlerNew.initializeCache();
            CacheHandlerNew.addProduct();
            CacheHandlerNew.getProduct();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            log.Error("Error: " + e.Message);
        }
        //try
        //{
        //    CacheHandler.initializeCache();
        //    CacheHandler.addProduct();
        //    try
        //    {
        //        Product p = CacheHandler.getProduct();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error: " + e.Message);
        //        log.Error("Error: " + e.Message);
        //    }
        //    Thread t = new(insertIntoCache);
        //    t.Start();
        //}
        //catch (SocketException e)
        //{
        //    Console.WriteLine("Error: " + e.Message);
        //    log.Error("Error: " + e.Message);
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine("Error: " + e.Message);
        //    log.Error("Error: " + e.Message);
        //}
        // string ip = "

        int portNumber = int.Parse(port);
        Client client = new(ip, portNumber);
        await client.StartAsync();

    }

    private static void ConfigureLogging()
    {
        var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
        XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
    }

    private static void insertIntoCache()
    {
        for (int i = 0; i < 1000000; i++)
        {
            CacheHandler.addRandomProduct();
            if (i % 1000 == 0)
            {
                Console.WriteLine($"Added {i} products to cache.");
                Thread.Sleep(1000);
            }

        }
    }
}
