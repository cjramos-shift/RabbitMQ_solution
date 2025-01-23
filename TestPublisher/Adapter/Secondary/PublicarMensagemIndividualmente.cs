using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using TestPublisher.Core.Abstracts;
using TestPublisher.Core.Ports;

namespace TestPublisher.Adapter.Secondary
{
    public class PublicarMensagemIndividualmente : IPublicarMensagensIndividualmente
    {
        private readonly IFactory _factory;

        private readonly IPublicarMensagensIndividualmenteService _publicarMensagensIndividualmenteService;

        public PublicarMensagemIndividualmente(IFactory factory, IPublicarMensagensIndividualmenteService publicarMensagensIndividualmenteService)
        {
            _factory = factory;
            _publicarMensagensIndividualmenteService = publicarMensagensIndividualmenteService;
        }

        public async Task PublicarMensagemIndividualmenteAsync(CreateChannelOptions channelOpts, BasicProperties props)
        {
            await _publicarMensagensIndividualmenteService.PublicarMensagemIndividualmenteAsync(_factory, channelOpts, props);
        }
    }
}
