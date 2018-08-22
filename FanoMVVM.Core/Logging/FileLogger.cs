using System;
using System.IO;
using System.Text;

namespace FanoMvvm.Logging
{
    /// <summary>
    /// Logger that write messages directory to a file
    /// </summary>
    public class FileLogger : GenericLogger
    {
        private readonly string _logPath;
        
        public FileLogger(string logPath)
        {
            _logPath = Path.GetFullPath(logPath);

            File.WriteAllText(_logPath, string.Empty);
        }


        protected override void LogAction(string formattedMessage)
        {
            using (var stream = new FileStream(_logPath, FileMode.Append, FileAccess.Write))
            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine(formattedMessage);
            }
        }
    }
}