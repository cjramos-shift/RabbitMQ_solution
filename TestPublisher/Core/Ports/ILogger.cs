using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPublisher.Core.Ports
{
    public interface ILogger
    {
        void LogError(string message);
        void LogInfo(string message);
        void LogInfoSW(Stopwatch sw);
    }
}
