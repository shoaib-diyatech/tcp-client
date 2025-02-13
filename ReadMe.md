# TCP Client

This project is a simple TCP client that connects to a TCP server using persistent sockets. It is designed to maintain a continuous connection to the server, allowing for reliable communication.

## Features

- Connects to a TCP server using persistent sockets
- Maintains a continuous connection
- Handles sending and receiving messages

## Requirements

- .NET 5.0 or later

## Getting Started

### Prerequisites

Ensure you have the following installed:

- .NET 5.0 SDK or later

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/tcp-client.git
    ```
2. Navigate to the project directory:
    ```sh
    cd tcp-client
    ```
3. Build the project:
    ```sh
    dotnet build
    ```

### Usage

1. Run the application:
    ```sh
    dotnet run
    ```
2. The client will attempt to connect to the TCP server at the specified IP address and port.

### Configuration

You can configure the server IP address and port in the `app.config` file:

```xml
     <add key="ip" value="127.0.0.1" />
     <add key="port" value="8080" />

```

You can configure the logs verbosity and path in `log4net.config` file:

```xml

  <file value="D:/logs/tcp-client/tcp-client.log" />

  <level value="INFO" />

```

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For any questions or suggestions, please open an issue or contact the repository owner.
