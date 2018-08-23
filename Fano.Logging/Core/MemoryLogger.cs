using System.Text;
using Fano.Logging.Core;

namespace Fano.Logging
{
    /// <inheritdoc />
    /// <summary>
    /// Generic logger class, maintains an in-memory log.
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