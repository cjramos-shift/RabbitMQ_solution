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

        Console.WriteLine(" [*] Aguardando retorno.");

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($" [x] Recebido: {message}");
            return Task.CompletedTask;
        };

        await channel.BasicConsumeAsync("testeFila", autoAck: true, consumer: consumer);
    }
}

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();