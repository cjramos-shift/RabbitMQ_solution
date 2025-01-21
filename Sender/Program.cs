using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory { HostName = "localhost", UserName = "admin", Password = "admin1" };
using (var connection = await factory.CreateConnectionAsync())
{
    using (var channel = await connection.CreateChannelAsync())
    {
        await channel.QueueDeclareAsync(queue: "testeFila", durable: false, exclusive: false, autoDelete: false,
        arguments: null);

        const string message = "Enviando mensagem exclusíva...";
        var body = Encoding.UTF8.GetBytes(message);


        await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "testeFila", body: body);

        Console.WriteLine($" [x] Enviado: {message}");
    }
}

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
