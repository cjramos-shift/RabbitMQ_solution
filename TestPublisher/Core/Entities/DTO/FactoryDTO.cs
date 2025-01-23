using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPublisher.Core.Abstracts;
using TestPublisher.Core.Exceptions;
using TestPublisher.Core.Ports;

namespace TestPublisher.Core.Entities.DTO
{
    public sealed class FactoryDTO
    {
        public string HostName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }

        private readonly IFactoryVo _factoryVo;

        public FactoryDTO(IFactoryVo factoryVo)
        {
            _factoryVo = factoryVo;

            HostName = Constantes.HostName;
            UserName = Constantes.UserName;
            Password = Constantes.Password;

            bool isCredenciaisValidas = _factoryVo.Validate(HostName, UserName, Password);

            if (!isCredenciaisValidas)
            {
                throw new InvalidFactorylException("Dados inválidos!");
            }
        }
    }
}
