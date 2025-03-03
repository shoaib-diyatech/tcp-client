# TCP Client

This project is a simple TCP client that connects to a Cache Service
- Uses Cache Library to connect to the Cache Service

# Configuration

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
