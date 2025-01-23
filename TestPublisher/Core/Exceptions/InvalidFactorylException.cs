using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPublisher.Core.Exceptions
{
    public class InvalidFactorylException : Exception
    {
        public InvalidFactorylException(string message) : base(message) { }
        public InvalidFactorylException(string message, object name) : base(message) { }
    }
}
