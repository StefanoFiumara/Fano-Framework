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
        private static string LogTitle => $"---- {DateTime.Now:F} ----";

        public event Action<LogEntry> LogEvent;
        public event Action InitEvent;

        private bool _isInit = false;
        
        public void Info(string message) => Log(message, LogLevel.Info);
        public void Warning(string message) => Log(message, LogLevel.Warning);
        public void Error(string message) => Log(message, LogLevel.Error);
        
        private void Log(string message, LogLevel level)
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