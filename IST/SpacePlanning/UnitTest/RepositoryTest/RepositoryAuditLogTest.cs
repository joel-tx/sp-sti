using IST.SpacePlanning.Data;
using IST.SpacePlanning.Data.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class RepositoryAuditLogTest : AbstractRepositoryTest
    {
        private AuditLog auditLog;

        [TestMethod]
        public void ShouldInsertAuditLogWhenDBContextIsValid()
        {
            CreateAuditLog();
            _spacePlanningUnitOfWork.AuditLogRepository.Add(auditLog);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.AuditLogRepository.GetById(auditLog.AuditLogId) != null);
        }

        [TestMethod]
        public void ShouldDeleteAuditLogWhenDBContextIsValid()
        {
            CreateAuditLog();
            _spacePlanningUnitOfWork.AuditLogRepository.Add(auditLog);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.AuditLogRepository.GetById(auditLog.AuditLogId) != null);
            _spacePlanningUnitOfWork.AuditLogRepository.Delete(auditLog);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.AuditLogRepository.GetById(auditLog.AuditLogId) == null);
        }

        [TestMethod]
        public void ShouldUpdateAuditLogWhenDBContextIsValid()
        {
            CreateAuditLog();
            string entry = "Table:{ name:\"table\", newData:{}, oldData:{}}";
            _spacePlanningUnitOfWork.AuditLogRepository.Add(auditLog);
            _spacePlanningUnitOfWork.Save();
            auditLog = _spacePlanningUnitOfWork.AuditLogRepository.GetById(auditLog.AuditLogId);
            auditLog.Entry = entry;
            _spacePlanningUnitOfWork.Save();
            Assert.AreEqual(entry, _spacePlanningUnitOfWork.AuditLogRepository.GetById(auditLog.AuditLogId).Entry);
        }

        [TestMethod]
        public void ShouldGetAuditLogWhenDBContextIsValid()
        {
            CreateAuditLog();
            _spacePlanningUnitOfWork.AuditLogRepository.Add(auditLog);
            _spacePlanningUnitOfWork.Save();
            auditLog = _spacePlanningUnitOfWork.AuditLogRepository.GetById(auditLog.AuditLogId);
            Assert.IsNotNull(auditLog);
        }        

        private void CreateAuditLog()
        {
            User user = FactoryUser.RandomCreate();
            _spacePlanningUnitOfWork.UserRepository.Add(user);
            
            LogLevel level = new LogLevel() { LogLevelId = 110, Name = "invalid user name" };
            _spacePlanningUnitOfWork.LogLevelRepository.Add(level);
            _spacePlanningUnitOfWork.Save();
            auditLog = new AuditLog()
            {
                AuditLogId = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                Entry = "Table:{ name:\"User\", oldData:\"email:juan.perez@gmail.com\", " +
                "newData:\"juan.perez@yahoo.com\"}",
                LevelId = 110,
                UserId = user.UserId,
            };
        }
    }
}
