using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;

namespace Fano.Logging.Core
{
    public class FileLoggerAsync : AbstractLogger
    {
        private readonly BlockingCollection<LogEntry> _logQueue;
        private readonly string _logPath;
        
        public FileLoggerAsync(string logPath)
        {
            _logPath = Path.GetFullPath(logPath);
            _logQueue = new BlockingCollection<LogEntry>();
            LogEvent += Enqueue;

            InitLogThread();
        }

        private void InitLogThread()
        {
            var logTask = Task.Run(() =>
            {
                File.WriteAllText(_logPath, string.Empty);
                using (var writer = new StreamWriter(_logPath))
                {
                    writer.WriteLine(GetLogHeader());
                }
                
                foreach (var logEntry in _logQueue.GetConsumingEnumerable())
                {
                    using (var writer = new StreamWriter(_logPath, append: true))
                    {
                        writer.WriteLine(logEntry.FormattedMessage);
                    }
                }
            });
        }

        private void Enqueue(LogEntry entry)
        {
            _logQueue.Add(entry);
        }
    }
}