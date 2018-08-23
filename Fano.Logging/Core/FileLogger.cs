using System.Collections.Generic;
using System.IO;

namespace Fano.Logging.Core
{
    /// <inheritdoc />
    /// <summary>
    /// Logger that write messages directory to a file
    /// </summary>
    public class FileLogger : AbstractLogger
    {
        private readonly string _logPath;
        
        public FileLogger(string logPath)
        {
            _logPath = Path.GetFullPath(logPath);

            File.WriteAllText(_logPath, string.Empty);

            InitEvent += WriteHeader;
            LogEvent += LogToFile;
            LogClearedEvent += ClearFile;
        }

        private void WriteHeader()
        {
            using (var writer = new StreamWriter(_logPath, append: true))
            {
                writer.WriteLine(GetLogHeader());
            }
        }


        private void LogToFile(LogEntry entry)
        {
            using (var writer = new StreamWriter(_logPath, append: true))
            {
                writer.WriteLine(entry.FormattedMessage);
            }
        }

        private void ClearFile()
        {
            File.WriteAllText(_logPath, GetLogHeader());
        }
    }
}