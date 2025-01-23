using System.Buffers.Binary;
using System.Diagnostics;
using System.Text;
using RabbitMQ.Client;
using TestPublisher.Core.Abstracts;
using TestPublisher.Core.Ports;
using TestPublisher.Core.Services;
using TestPublisher.Adapter.Secondary;
using TestPublisher.Core.ValueObjects;

bool debug = true;

var channelOpts = new CreateChannelOptions(
    publisherConfirmationsEnabled: true,
    publisherConfirmationTrackingEnabled: true,
    outstandingPublisherConfirmationsRateLimiter: new ThrottlingRateLimiter(Constantes.MAX_OUTSTANDING_CONFIRMS)
);

var props = new BasicProperties
{
    Persistent = true
};

IFactoryVo factoryVo = new FactoryVo();
IFactory factory = new FactoryService(factoryVo);
ILogger logger = new Logger();
IPublicarMensagensIndividualmenteService publicarMensagensIndividualmenteService = new PublicarMensagensIndividualmenteService(logger);
IPublicarMensagensIndividualmente publicarMensagensIndividualmente = new PublicarMensagemIndividualmente(factory, publicarMensagensIndividualmenteService);

#pragma warning disable CS8321 // Local function is declared but never used

await PublishMessagesIndividuallyAsync();

async Task PublishMessagesIndividuallyAsync()
{
    logger.LogInfo($"publishing {Constantes.MESSAGE_COUNT:N0} messages and handling confirms per-message");
    await publicarMensagensIndividualmente.PublicarMensagemIndividualmenteAsync(channelOpts, props);
}
