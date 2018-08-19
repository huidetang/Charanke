using Prism.Logging;
using System.Diagnostics;

namespace Gribouillage.Tests.Mocks
{
    public class TraceLogger : ILoggerFacade
    {
        public void Log(string message, Category category, Priority priority)
        {
            Trace.WriteLine($"{category} - {priority}: {message}");
        }
    }
}
