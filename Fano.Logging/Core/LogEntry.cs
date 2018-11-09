using System;

namespace Fano.Logging.Core
{
    public class LogEntry
    {
        public DateTime Timestamp { get; set; }
        public LogLevel LogLevel { get; set; }
        public string Message { get; set; }

        private string Prefix =>  $" |^|{LogLevel.ToString().ToUpper()}|^| ";

        public string FormattedMessage => $"{Timestamp:HH:mm:ss}{Prefix}{Message}";
    }
}