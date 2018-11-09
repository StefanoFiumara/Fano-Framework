using System;
using System.Collections.Generic;

namespace Fano.Logging.Core
{
    /// <inheritdoc />
    /// <summary>
    /// Logger that writes messages to the C# Console
    /// </summary>
    public class ConsoleLogger : AbstractLogger
    {
        public ConsoleLogger()
        {
            InitEvent += WriteHeader;
            LogEvent += LogToConsole;
        }

        private void WriteHeader()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(GetLogHeader());
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void LogToConsole(LogEntry entry)
        {
            switch (entry.LogLevel)
            {
                case LogLevel.None:
                case LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }

            Console.WriteLine(entry.FormattedMessage);

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}