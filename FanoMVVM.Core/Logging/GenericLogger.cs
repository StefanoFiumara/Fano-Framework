using System;
using System.Text;

namespace FanoMvvm.Logging
{
    /// <summary>
    /// Generic logger that routes messages to a custom action
    /// </summary>
    public abstract class GenericLogger : ILogger
    {
        private readonly StringBuilder _logSession;
        private readonly string _logTitle = $"---- Session Log - {DateTime.Now:F} ----";

        protected GenericLogger()
        {
            _logSession = new StringBuilder();
        }

        protected abstract void LogAction(string formattedMessage);

        public void Info(string message) => Write(message, LogLevel.Info);
        public void Warning(string message) => Write(message, LogLevel.Warning);
        public void Error(string message) => Write(message, LogLevel.Error);

        public string GetCurrentSessionLog() => _logSession.ToString();

        private void Write(string message, LogLevel level)
        {
            if (_logSession.Length == 0)
            {
                WriteLogHeader();
                _logSession.AppendLine();
            }

            string prefix = level == LogLevel.Info ? string.Empty : $"{level.ToString().ToUpper()}: ";
            string formattedMessage = level == LogLevel.None ? message : $"{DateTime.Now:HH:mm:ss} -- {prefix}{message}";

            LogAction(formattedMessage);
            _logSession.AppendLine(formattedMessage);
        }

        private void WriteLogHeader()
        {
            var headerDecor = new string('-', _logTitle.Length);

            _logSession.AppendLine(headerDecor);
            _logSession.AppendLine(_logTitle);
            _logSession.Append(headerDecor);

            var header = _logSession.ToString();
            LogAction(header);
        }
    }
}