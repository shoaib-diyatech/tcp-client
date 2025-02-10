using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

class Program
{
    public static readonly ILog log = LogManager.GetLogger(typeof(TcpClient));
    static async Task Main()
    {
        Console.WriteLine("Client App Started.");
        log.Info("Client App Started.");
        Client client = new("127.0.0.1", 8080); // Connect to localhost server
        await client.StartAsync();
    }


    private static void ConfigureLogging()
    {
        var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
        XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
    }
}
