using Prism.Logging;
using System.Diagnostics;

namespace Charanke.Tests.Mocks
{
    public class TraceLogger : ILoggerFacade
    {
        public void Log(string message, Category category, Priority priority)
        {
            Trace.WriteLine($"{category} - {priority}: {message}");
        }
    }
}
