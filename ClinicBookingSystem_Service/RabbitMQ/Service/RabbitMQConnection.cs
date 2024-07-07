using ClinicBookingSystem_Service.RabbitMQ.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
namespace ClinicBookingSystem_Service.RabbitMQ.Service;

public class RabbitMQConnection
{
    private readonly RabbitMQConfig _rabbitMQConfig;
    private IConnection _connection;
    private global::RabbitMQ.Client.IModel _channel;
    public RabbitMQConnection(IOptions<RabbitMQConfig> rabbitMQConnection)
    {
        _rabbitMQConfig = rabbitMQConnection.Value;
        var factory = new ConnectionFactory
        {
            HostName = _rabbitMQConfig.HostName,
            UserName = _rabbitMQConfig.UserName,
            Password = _rabbitMQConfig.Password,
            Port = _rabbitMQConfig.Port
        };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }
    public IConnection GetConnection()
    {
        return _connection;
    }
    public void Close()
    {
        _connection.Close();
    }
}