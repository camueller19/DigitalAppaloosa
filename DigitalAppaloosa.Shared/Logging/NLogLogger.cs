﻿using Prism.Logging;
using NLog;

namespace DigitalAppaloosa.Shared.Logging
{
    public class NLogLogger : ILoggerFacade
    {
        private readonly ILogger nLogger = LogManager.GetCurrentClassLogger();

        public void Log(string message, Category category, Priority priority)
        {
            switch (category)
            {
                case Category.Debug:
                    nLogger.Debug(message);
                    break;
                case Category.Exception:
                    nLogger.Error(message);
                    break;
                case Category.Info:
                    nLogger.Info(message);
                    break;
                case Category.Warn:
                    nLogger.Warn(message);
                    break;

            }
            //throw new NotImplementedException();
        }
    }
}
