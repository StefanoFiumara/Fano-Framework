using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fano.Logging.Core
{
    /// <summary>
    /// Base logger class, publishes events when the log is to be updated.
    /// </summary>
    public abstract class AbstractLogger : ILogger
    {
        private static string LogTitle => $"---- Session Log - {DateTime.Now:F} ----";

        public event Action LogClearedEvent;
        public event Action<LogEntry> LogEvent;
        public event Action InitEvent;

        private bool _isInit = false;
        private readonly Queue<LogEntry> _logEntries;

        protected AbstractLogger()
        {
            _logEntries = new Queue<LogEntry>(256);
        }

        public void Info(string message) => Write(message, LogLevel.Info);
        public void Warning(string message) => Write(message, LogLevel.Warning);
        public void Error(string message) => Write(message, LogLevel.Error);

        public void Clear() => LogClearedEvent?.Invoke();

        public IEnumerable<LogEntry> GetLogEntries() => _logEntries.AsEnumerable();

        private void Write(string message, LogLevel level)
        {
            if (!_isInit)
            {
                _isInit = true;
                InitEvent?.Invoke();
            }
            
            var entry = new LogEntry
            {
                Timestamp = DateTime.Now,
                Message = message,
                LogLevel = level
            };

            //In memory log entries are capped to 255
            if (_logEntries.Count >= 255) _logEntries.Dequeue();

            _logEntries.Enqueue(entry);

            LogEvent?.Invoke(entry);
        }
        
        protected string GetLogHeader()
        {
            var sb = new StringBuilder();

            var headerDecor = new string('-', LogTitle.Length);

            sb.AppendLine(headerDecor);
            sb.AppendLine(LogTitle);
            sb.Append(headerDecor);

            return sb.ToString();
        }
    }
}