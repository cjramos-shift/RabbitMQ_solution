using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPublisher.Core.Ports
{
    public interface IFactoryVo
    {
        bool Validate(string _hostName, string _userName, string _password);
    }
}
