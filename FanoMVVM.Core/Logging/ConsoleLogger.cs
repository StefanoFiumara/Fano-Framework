using System;
using System.Text;

namespace FanoMvvm.Logging
{
    /// <summary>
    /// Logger that writes messages to the C# Console
    /// </summary>
    public class ConsoleLogger : GenericLogger
    {
        protected override void LogAction(string formattedMessage)
        {
            Console.WriteLine(formattedMessage);
        }
    }
}