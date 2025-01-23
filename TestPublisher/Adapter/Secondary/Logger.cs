using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPublisher.Core.Abstracts;
using TestPublisher.Core.Ports;

namespace TestPublisher.Adapter.Secondary
{
    public class Logger : ILogger
    {
        public void LogError(string message)
        {
            Console.WriteLine($"{DateTime.Now} [ERROR] saw nack or return, ex: {message}");
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"{DateTime.Now} [INFO] {message}");
        }

        public void LogInfoSW(Stopwatch sw)
        {
            Console.WriteLine($"{DateTime.Now} [INFO] published {Constantes.MESSAGE_COUNT:N0} messages individually in {sw.ElapsedMilliseconds:N0} ms");
        }
    }
}
