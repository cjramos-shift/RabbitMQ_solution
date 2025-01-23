using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPublisher.Core.Entities;
using TestPublisher.Core.Entities.DTO;
using TestPublisher.Core.Exceptions;
using TestPublisher.Core.Ports;

namespace TestPublisher.Core.ValueObjects
{
    public class FactoryVo : IFactoryVo
    {
        public string HostName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(HostName) ||
                !string.IsNullOrEmpty(UserName) ||
                !string.IsNullOrEmpty(Password);
        }

        public bool Validate(string _hostName, string _userName, string _password)
        {
            HostName = _hostName;
            UserName = _userName;
            Password = _password;

            if (!IsValid())
            {
                return false;
            }

            return true;
        }
    }
}
