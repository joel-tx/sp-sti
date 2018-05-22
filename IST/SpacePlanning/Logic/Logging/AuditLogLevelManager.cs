using IST.SpacePlanning.Data;
using IST.SpacePlanning.Data.EntityModel;
using IST.SpacePlanning.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IST.SpacePlanning.Logic.Logging
{
    public class AuditLogLevelManager : IAuditLogLevelManager
    {
        private IRepository<AuditLog> _auditLogRepository;
        private LogLevelRepository _logLevelRepository;       
        private UnitOfWork _unitOfWork;

        public AuditLogLevelManager()
        {
            _unitOfWork = new UnitOfWork();
            _auditLogRepository = _unitOfWork.AuditLogRepository;
            _logLevelRepository = _unitOfWork.LogLevelRepository;
        }

        public AuditLogLevelManager(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _auditLogRepository = _unitOfWork.AuditLogRepository;
            _logLevelRepository = _unitOfWork.LogLevelRepository;
        }

        /// <summary>
        /// Saves audit log entry into the database
        /// </summary>
        /// <param name="description">log level description</param>
        /// <param name="logLevelCode">log level code</param>
        /// <param name="userId">user identifier</param>
        public void SaveLogEntry(string description, LogLevelCodes logLevelCode, Guid userId)
        {
            AuditLog auditEntry = new AuditLog() { AuditLogId = Guid.NewGuid(), CreateDate = DateTime.UtcNow,
                Entry = description, LevelId = (long)logLevelCode, UserId = userId };

            _auditLogRepository.Add(auditEntry);
            _unitOfWork.Save();
        }
    }
}
