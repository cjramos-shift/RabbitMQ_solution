using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using TestPublisher.Core.Abstracts;
using TestPublisher.Core.Ports;

namespace TestPublisher.Core.Services
{
    public class PublicarMensagensIndividualmenteService : IPublicarMensagensIndividualmenteService
    {
        private readonly ILogger _logger;
        public PublicarMensagensIndividualmenteService(ILogger logger)
        {
            _logger = logger;
        }

        public async Task PublicarMensagemIndividualmenteAsync(IFactory factory, CreateChannelOptions channelOpts, BasicProperties props)
        {
            await using (var connection = await factory.CriarConexaoAsync())
            {
                await using (var channel = await connection.CreateChannelAsync(channelOpts))
                {
                    // declare a server-named queue
                    QueueDeclareOk queueDeclareResult = await channel.QueueDeclareAsync();
                    string queueName = queueDeclareResult.QueueName;

                    var sw = new Stopwatch();

                    sw.Start();

                    for (int i = 0; i < Constantes.MESSAGE_COUNT; i++)
                    {
                        byte[] body = Encoding.UTF8.GetBytes(i.ToString());
                        try
                        {
                            await channel.BasicPublishAsync(exchange: string.Empty, routingKey: queueName, body: body, basicProperties: props, mandatory: true);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex.Message);
                        }
                    }

                    sw.Stop();

                    _logger.LogInfoSW(sw);
                }
            }
        }
    }
}
