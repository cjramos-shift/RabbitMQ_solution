using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using TestPublisher.Core.Ports;

namespace TestPublisher.Core.Entities
{
    public class Factory : IFactory
    {
        public Task<IConnection> CriarConexaoAsync()
        {
            var factory = new ConnectionFactory { HostName = hostname, UserName = "admin", Password = "admin1" };
            return factory.CreateConnectionAsync();
        }
    }
}
