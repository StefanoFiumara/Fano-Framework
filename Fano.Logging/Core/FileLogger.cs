using System.IO;

namespace Fano.Logging.Core
{
    /// <inheritdoc />
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

            InitEvent += () => LogToFile(GetLogHeader(), LogLevel.None);
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