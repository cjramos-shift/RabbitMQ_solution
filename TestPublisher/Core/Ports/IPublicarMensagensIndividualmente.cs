﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace TestPublisher.Core.Ports
{
    public interface IPublicarMensagensIndividualmente
    {
        Task PublicarMensagemIndividualmenteAsync(CreateChannelOptions channelOpts, BasicProperties props);
    }
}
