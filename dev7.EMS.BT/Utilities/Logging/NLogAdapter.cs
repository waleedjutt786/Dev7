//using System;
//using System.Threading.Tasks;
//using NLog;

//namespace dev7.EMS.Framework.Logging
//{
//    /// <summary>
//    /// An adapter for mapping NLog.ILogger to ILogManager
//    /// </summary>
//    /// <seealso cref="ILogManager"/>
//    public class NLogAdapter : ILogManager
//    {
//        #region properties

//        public readonly ILogger Adaptee;

//        #endregion properties

//        #region methods

//        public void Log(LogEntry entry)
//        {
//            if (entry == default(LogEntry)) throw new ArgumentNullException(nameof(entry));

//            switch (entry.Severity)
//            {
//                case LoggingEventType.Trace:
//                    LogTrace(entry);
//                    break;

//                case LoggingEventType.Debug:
//                    LogDebug(entry);
//                    break;

//                case LoggingEventType.Info:
//                    LogInfo(entry);
//                    break;

//                case LoggingEventType.Warn:
//                    LogWarn(entry);
//                    break;

//                case LoggingEventType.Error:
//                    LogError(entry);

//                    break;

//                case LoggingEventType.Fatal:
//                    LogFatal(entry);
//                    break;

//                default:
//                    throw new ArgumentOutOfRangeException();
//            }
//        }

//        public void Log(string message)
//        {
//            Log(new LogEntry(LoggingEventType.Info, message, null));
//        }

//        public Task LogAsync(string message)
//        {
//            // Log(new LogEntry(LoggingEventType.Info, message, null));
//            throw new NotImplementedException();
//        }

//        public Task LogAsync(LogEntry entry)
//        {
//            throw new NotImplementedException();
//        }

//        /// <summary>
//        /// Logs the warn.
//        /// </summary>
//        /// <param name="entry">The entry.</param>
//        private void LogWarn(LogEntry entry)
//        {
//            if (entry.Exception != null && !string.IsNullOrWhiteSpace(entry.Message))
//                Adaptee.Warn(entry.Exception, entry.Message);
//            else if (entry.Exception != null)
//                Adaptee.Warn(entry.Exception);
//            else if (!string.IsNullOrWhiteSpace(entry.Message))
//                Adaptee.Warn(entry.Message);
//            else
//                Adaptee.Warn("Warn: No Message Supplied");
//        }

//        /// <summary>
//        /// Logs the information.
//        /// </summary>
//        /// <param name="entry">The entry.</param>
//        private void LogInfo(LogEntry entry)
//        {
//            if (entry.Exception != null && !string.IsNullOrWhiteSpace(entry.Message))
//                Adaptee.Info(entry.Exception, entry.Message);
//            else if (entry.Exception != null)
//                Adaptee.Info(entry.Exception);
//            else if (!string.IsNullOrWhiteSpace(entry.Message))
//                Adaptee.Info(entry.Message);
//            else
//                Adaptee.Info("Info: No Message Supplied");
//        }

//        /// <summary>
//        /// Logs the debug.
//        /// </summary>
//        /// <param name="entry">The entry.</param>
//        private void LogDebug(LogEntry entry)
//        {
//            if (entry.Exception != null && !string.IsNullOrWhiteSpace(entry.Message))
//                Adaptee.Debug(entry.Exception, entry.Message);
//            else if (entry.Exception != null)
//                Adaptee.Debug(entry.Exception);
//            else if (!string.IsNullOrWhiteSpace(entry.Message))
//                Adaptee.Debug(entry.Message);
//            else
//                Adaptee.Debug("Debug: No Message Supplied");
//        }

//        /// <summary>
//        /// Logs the trace.
//        /// </summary>
//        /// <param name="entry">The entry.</param>
//        private void LogTrace(LogEntry entry)
//        {
//            if (entry.Exception != null && !string.IsNullOrWhiteSpace(entry.Message))
//                Adaptee.Trace(entry.Exception, entry.Message);
//            else if (entry.Exception != null)
//                Adaptee.Trace(entry.Exception);
//            else if (!string.IsNullOrWhiteSpace(entry.Message))
//                Adaptee.Trace(entry.Message);
//            else
//                Adaptee.Trace("Trace: No Message Supplied");
//        }

//        /// <summary>
//        /// Processes the error.
//        /// </summary>
//        /// <param name="entry">The entry.</param>
//        private void LogError(LogEntry entry)
//        {
//            if (entry.Exception != null && !string.IsNullOrWhiteSpace(entry.Message))
//                Adaptee.Error(entry.Exception, entry.Message);
//            else if (entry.Exception != null)
//                Adaptee.Error(entry.Exception);
//            else if (!string.IsNullOrWhiteSpace(entry.Message))
//                Adaptee.Error(entry.Message);
//            else
//                Adaptee.Error("Error: No Message Supplied");
//        }

//        /// <summary>
//        /// Processes the fatal.
//        /// </summary>
//        /// <param name="entry">The entry.</param>
//        private void LogFatal(LogEntry entry)
//        {
//            if (entry.Exception != null && !string.IsNullOrWhiteSpace(entry.Message))
//                Adaptee.Fatal(entry.Exception, entry.Message);
//            else if (entry.Exception != null)
//                Adaptee.Fatal(entry.Exception);
//            else if (!string.IsNullOrWhiteSpace(entry.Message))
//                Adaptee.Fatal(entry.Message);
//            else
//                Adaptee.Fatal("Fatal: No Message Supplied");
//        }

//        #endregion methods

//        #region ctor

//        /// <summary>
//        /// Initializes a new instance of the <see cref="NLogAdapter"/> class.
//        /// </summary>
//        /// <param name="adaptee">The adaptee.</param>
//        /// <param name="callerPath">The caller path.</param>
//        public NLogAdapter(string callerPath, ILogger adaptee = null)
//        {
//            Adaptee = adaptee ?? LogManager.GetLogger(callerPath);
//        }

//        #endregion ctor
//    }
//}