using IST.SpacePlanning.Data.EntityModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class RepositoryLogLevelTest : AbstractRepositoryTest
    {
        private LogLevel logLevel;

        [TestMethod]
        public void ShouldInsertWhenDBContextLogLevelIsValid()
        {
            logLevel = CreateLogLevel();
            _spacePlanningUnitOfWork.LogLevelRepository.Add(logLevel);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.LogLevelRepository.GetById(logLevel.LogLevelId) != null);
        }

        [TestMethod]
        public void ShouldDeleteLogLevelWhenDBContextIsValid()
        {
            logLevel = CreateLogLevel();
            _spacePlanningUnitOfWork.LogLevelRepository.Add(logLevel);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.LogLevelRepository.GetById(logLevel.LogLevelId) != null);
            _spacePlanningUnitOfWork.LogLevelRepository.Delete(logLevel);
            _spacePlanningUnitOfWork.Save();
            Assert.IsTrue(_spacePlanningUnitOfWork.LogLevelRepository.GetById(logLevel.LogLevelId) == null);
        }

        [TestMethod]
        public void ShouldUpdateLogLevelWhenDBContextIsValid()
        {
            logLevel = CreateLogLevel();
            string newName = "Verbose";
            _spacePlanningUnitOfWork.LogLevelRepository.Add(logLevel);
            _spacePlanningUnitOfWork.Save();
            logLevel = _spacePlanningUnitOfWork.LogLevelRepository.GetById(logLevel.LogLevelId);
            logLevel.Name = newName;
            _spacePlanningUnitOfWork.Save();
            Assert.AreEqual(newName, _spacePlanningUnitOfWork.LogLevelRepository.GetById(logLevel.LogLevelId).Name);
        }

        [TestMethod]
        public void ShouldGetLogLevelWhenDBContextIsValid()
        {
            logLevel = CreateLogLevel();
            _spacePlanningUnitOfWork.LogLevelRepository.Add(logLevel);
            _spacePlanningUnitOfWork.Save();
            logLevel = _spacePlanningUnitOfWork.LogLevelRepository.GetById(logLevel.LogLevelId);
            Assert.IsNotNull(logLevel);
        }

        private LogLevel CreateLogLevel()
        {
            logLevel = new LogLevel() { LogLevelId = 100, Name = "error",
                Description = "an expected error occurred while trying to save Log Level" };
            return logLevel;
        }

    }
}
