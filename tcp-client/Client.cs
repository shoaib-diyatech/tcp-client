using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


class Client
{

    private readonly string _serverIp;
    private readonly int _port;

    public Client(string serverIp, int port)
    {
        _serverIp = serverIp;
        _port = port;
    }

    public async Task StartAsync()
    {
        try
        {
            using TcpClient client = new();
            await client.ConnectAsync(_serverIp, _port);
            Program.log.Info($"Connected to server on IP: [{_serverIp}], Port: [{_port}]");
            Console.WriteLine("Connected to server.");

            NetworkStream stream = client.GetStream();
            while (true)
            {
                Console.Write("Enter command (CREATE/READ/UPDATE/DELETE key [value]): ");
                Program.log.Info("Enter command (CREATE/READ/UPDATE/DELETE key [value]): ");
                string command = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(command)) break;

                byte[] buffer = Encoding.UTF8.GetBytes(command);
                await stream.WriteAsync(buffer, 0, buffer.Length);

                buffer = new byte[1024];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Server Response: {response}");
                Program.log.Debug($"Server Response: {response}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Program.log.Error($"Error: {ex.Message}");
        }
    }
}
