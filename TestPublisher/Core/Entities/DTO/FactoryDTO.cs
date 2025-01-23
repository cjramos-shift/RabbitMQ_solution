using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPublisher.Core.Exceptions;

namespace TestPublisher.Core.Entities.DTO
{
    public sealed class FactoryDTO
    {
        public string HostName { get; }
        public string UserName { get; }
        public string Password { get; }

        public FactoryDTO(string hostName, string userName, string password)
        {
            HostName = hostName ?? throw new InvalidFactorylException(nameof(hostName));
            UserName = userName ?? throw new InvalidFactorylException(nameof(userName));
            Password = password ?? throw new InvalidFactorylException(nameof(password));

            if (string.IsNullOrWhiteSpace(hostName))
                throw new InvalidFactorylException("Host name cannot be empty", nameof(hostName));

            if (string.IsNullOrWhiteSpace(userName))
                throw new InvalidFactorylException("User name cannot be empty", nameof(userName));

            if (string.IsNullOrWhiteSpace(password))
                throw new InvalidFactorylException("Password cannot be empty", nameof(password));
        }
    }
}
