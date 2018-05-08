using NLog;
using System;

namespace ImageRetriever.Logging
{
    public class NLogLogger : ILogger
    {
        private readonly Logger logger;

        public NLogLogger(Logger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Error(Exception ex, string msg)
        {
            logger.Error(ex, msg);
        }

        public void Info(string msg)
        {
            logger.Info(msg);
        }

        public void Warn(string msg)
        {
            logger.Warn(msg);
        }
    }
}
