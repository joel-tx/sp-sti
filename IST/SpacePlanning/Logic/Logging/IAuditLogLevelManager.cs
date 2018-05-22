using System;
using System.Collections.Generic;
using System.Text;

namespace IST.SpacePlanning.Logic.Logging
{
    public interface IAuditLogLevelManager
    {
        /// <summary>
        /// Saves audit log entry into the database
        /// </summary>
        /// <param name="description">log level description</param>
        /// <param name="logLevelCode">log level code</param>
        /// <param name="userId">user identifier</param>
        void SaveLogEntry(string description, LogLevelCodes logLevel, Guid userId);
    }
}
