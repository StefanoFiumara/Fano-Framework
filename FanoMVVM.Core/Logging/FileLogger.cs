using System;
using System.IO;
using System.Text;

namespace FanoMvvm.Logging
{
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

            LogEvent += LogToFile;
            LogClearedEvent += ClearFile;
        }


        private void LogToFile(string formattedMessage, LogLevel level)
        {
            using (var writer = new StreamWriter(_logPath, append: true))
            {
                writer.WriteLine(formattedMessage);
            }
        }

        private void ClearFile()
        {
            File.WriteAllText(_logPath, string.Empty);
        }

        public override string GetCurrentSessionLog()
        {
            return File.ReadAllText(_logPath);
        }
    }
}