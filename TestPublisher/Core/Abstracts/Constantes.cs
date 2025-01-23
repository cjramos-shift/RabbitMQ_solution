using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPublisher.Core.Abstracts
{
    public static class Constantes
    {
        public const string HostName = "localhost";
        public const string UserName = "admin";
        public const string Password = "admin1";
        public const ushort MAX_OUTSTANDING_CONFIRMS = 256;
        public const int MESSAGE_COUNT = 50_000;
    }
}
