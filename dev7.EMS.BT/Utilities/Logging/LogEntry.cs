using System;

namespace dev7.EMS.Framework.Logging
{
    /// <summary>
    /// Log Entry
    /// </summary>
    public class LogEntry
    {
        public LogEntry(LoggingEventType severity, string message, Exception exception = null)
        {
            Severity = severity;
            Message = message;
            Exception = exception;
        }

        public LoggingEventType Severity { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}