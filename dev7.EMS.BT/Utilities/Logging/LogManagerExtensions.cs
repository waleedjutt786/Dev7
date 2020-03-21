using System;

namespace dev7.EMS.Framework.Logging
{
    public static class LogManagerExtensions
    {
        /// <summary>
        /// Logs message as Info level severity.
        /// </summary>
        /// <param name="logManager">The logManager.</param>
        /// <param name="message">The message.</param>
        public static void Log(this ILogManager logManager, string message)
        {
            logManager.Log(new LogEntry(LoggingEventType.Info, message));
        }

        /// <summary>
        /// Logs the message by the specified severity.
        /// </summary>
        /// <param name="logManager">The logManager.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="message">The message.</param>
        public static void Log(this ILogManager logManager, LoggingEventType severity, string message)
        {
            logManager.Log(new LogEntry(severity, message));
        }

        /// <summary>
        /// Logs the exception and message by the specified severity.
        /// </summary>
        /// <param name="logManager">The logManager.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void Log(this ILogManager logManager, LoggingEventType severity, string message, Exception exception)
        {
            logManager.Log(new LogEntry(severity, message, exception));
        }

        /// <summary>
        /// Logs the exception by the specified severity.
        /// </summary>
        /// <param name="logManager">The logManager.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="exception">The exception.</param>
        public static void Log(this ILogManager logManager, LoggingEventType severity, Exception exception)
        {
            logManager.Log(new LogEntry(severity, default(string), exception));
        }

        /// <summary>
        /// Logs the exception with error level severity.
        /// </summary>
        /// <param name="logManager">The logManager.</param>
        /// <param name="exception">The exception.</param>
        public static void Log(this ILogManager logManager, Exception exception)
        {
            logManager.Log(new LogEntry(LoggingEventType.Error, exception.Message, exception));
        }
    }
}