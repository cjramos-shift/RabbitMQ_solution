using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPublisher.Core.Entities;
using TestPublisher.Core.Entities.DTO;
using TestPublisher.Core.Exceptions;

namespace TestPublisher.Core.ValueObjects
{
    public class FactoryVo
    {
        public FactoryVo(string _hostName, string _userName, string _password)
        {
            var factory = new FactoryDTO(_hostName, _userName, _password);
            Factory = factory;

            Validate();
        }

        public FactoryDTO Factory { get; private set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Factory.HostName) ||
                !string.IsNullOrEmpty(Factory.UserName) ||
                !string.IsNullOrEmpty(Factory.Password);
        }

        private void Validate()
        {
            if (!IsValid())
            {
                throw new InvalidFactorylException("Dados inválidos!");
            }
        }
    }
}
