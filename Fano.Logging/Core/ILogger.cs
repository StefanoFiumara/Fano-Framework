using System.Collections;
using System.Collections.Generic;

namespace Fano.Logging.Core
{
    public interface ILogger
    {
        void Info(string message);
        void Warning(string message);
        void Error(string message);

        void Clear();

        IEnumerable<LogEntry> GetLogEntries();
    }
}