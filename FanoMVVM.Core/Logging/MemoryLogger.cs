using System.Text;

namespace FanoMvvm.Logging
{
    /// <inheritdoc />
    /// <summary>
    /// Generic logger class, maintains an in-memory log.
    /// Publishes events when the log is updated.
    /// </summary>
    public class MemoryLogger : AbstractLogger
    {
        private readonly StringBuilder _logSession;
        
        protected MemoryLogger()
        {
            _logSession = new StringBuilder();

            InitEvent += () => _logSession.AppendLine(GetLogHeader());
            LogEvent += (msg, level) => _logSession.AppendLine(msg);
            LogClearedEvent += () => _logSession.Clear();
        }

        public override string GetCurrentSessionLog()
        {
            return _logSession.ToString();
        }
    }
}