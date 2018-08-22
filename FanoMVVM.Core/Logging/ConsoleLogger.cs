using System;
using System.Text;

namespace FanoMvvm.Logging
{
    /// <inheritdoc />
    /// <summary>
    /// Logger that writes messages to the C# Console
    /// </summary>
    public class ConsoleLogger : MemoryLogger
    {
        public ConsoleLogger()
        {
            InitEvent += () => LogToConsole(GetLogHeader(), LogLevel.None);

            LogClearedEvent += Console.Clear;
            LogEvent += LogToConsole;
        }

        private void LogToConsole(string message, LogLevel level)
        {
            switch (level)
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

            Console.WriteLine(message);

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}