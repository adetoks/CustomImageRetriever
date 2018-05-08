using System;

namespace ImageRetriever.Logging
{
    public interface ILogger
    {
        void Error(Exception ex, string msg);
        void Warn(string msg);
        void Info(string msg);
    }
}
