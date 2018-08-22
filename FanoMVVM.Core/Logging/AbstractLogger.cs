using System;
using System.Text;

namespace FanoMvvm.Logging
{
    /// <summary>
    /// Base logger class, publishes events when the log is to be updated.
    /// </summary>
    public abstract class AbstractLogger : ILogger
    {
        private static string LogTitle => $"---- Session Log - {DateTime.Now:F} ----";

        public event Action LogClearedEvent;
        public event Action<string, LogLevel> LogEvent;
        public event Action InitEvent;

        private bool _isInit = false;

        public void Info(string message) => Write(message, LogLevel.Info);
        public void Warning(string message) => Write(message, LogLevel.Warning);
        public void Error(string message) => Write(message, LogLevel.Error);

        public void Clear()
        {
            LogClearedEvent?.Invoke();
        }

        private void Write(string message, LogLevel level)
        {
            if (!_isInit)
            {
                _isInit = true;
                InitEvent?.Invoke();
            }

            var msg = FormatMessage(message, level);
            LogEvent?.Invoke(msg, level);
        }

        private string FormatMessage(string message, LogLevel level)
        {
            string prefix = level == LogLevel.Info ? string.Empty : $"{level.ToString().ToUpper()}: ";
            string formattedMessage = level == LogLevel.None ? message : $"{DateTime.Now:HH:mm:ss} -- {prefix}{message}";

            return formattedMessage;
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

        public abstract string GetCurrentSessionLog();
    }
}