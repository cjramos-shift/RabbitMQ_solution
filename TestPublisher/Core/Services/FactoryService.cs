using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using TestPublisher.Core.Entities.DTO;
using TestPublisher.Core.Ports;

namespace TestPublisher.Core.Services
{
    public class FactoryService : IFactory
    {
        private IFactoryVo _factoryVo;

        public FactoryService(IFactoryVo factoryVo)
        {
            _factoryVo = factoryVo;
        }

        public Task<IConnection> CriarConexaoAsync()
        {
            FactoryDTO _factory = new FactoryDTO(_factoryVo);

            var factory = new ConnectionFactory { HostName = _factory.HostName, UserName = _factory.UserName, Password = _factory.Password };
            return factory.CreateConnectionAsync();
        }
    }
}
