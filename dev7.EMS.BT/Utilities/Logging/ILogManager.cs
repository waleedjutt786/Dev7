using System.Threading.Tasks;

namespace dev7.EMS.Framework.Logging
{
    // http://stackoverflow.com/questions/5646820/logger-wrapper-best-practice
    //http://www.danesparza.net/2014/06/things-your-dad-never-told-you-about-nlog/
    //http://stackoverflow.com/questions/4091606/most-useful-nlog-configurations
    //https://github.com/NLog
    /// <summary>
    /// Abstraction of a Logger implementation
    /// </summary>
    public interface ILogManager
    {
        /// <summary>
        /// Logs the specified message with LoggingEventType Info
        /// </summary>
        /// <param name="message">The message.</param>
        void Log(string message);

        /// <summary>
        /// Logs the specified entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        void Log(LogEntry entry);

        Task LogAsync(string message);

        Task LogAsync(LogEntry entry);
    }
}