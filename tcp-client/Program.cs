using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System.Configuration;

class Program
{
    public static readonly ILog log = LogManager.GetLogger(typeof(TcpClient));
    static async Task Main()
    {
        Console.WriteLine("Client App Started.");
        ConfigureLogging();
        log.Info("Client App Started.");
        string port = ConfigurationManager.AppSettings["port"] ?? "8080";
        string ip = ConfigurationManager.AppSettings["ip"] ?? "127.0.0.1";
        Console.WriteLine($"Connecting to TCP-SERVER on IP: [{ip}], Port: [{port}]");
        log.Info($"Connecting to TCP-SERVER on IP: [{ip}], Port: [{port}]");

        int portNumber = int.Parse(port);
        Client client = new(ip, portNumber); 
        await client.StartAsync();
    }


    private static void ConfigureLogging()
    {
        var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
        XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
    }
}
