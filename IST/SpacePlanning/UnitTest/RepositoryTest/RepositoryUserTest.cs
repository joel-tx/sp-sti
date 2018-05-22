using IST.SpacePlanning.Data;
using IST.SpacePlanning.Data.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestSupport.EfHelpers;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class RepositoryUserTest
    {
        private UnitOfWork spacePlanningUnitWork;
        private DbContextOptions<ISTSpacePlanningContext> dbOptions;
        private ISTSpacePlanningContext context;
        private User testUser;

        [TestInitialize]
        public void SetUp()
        {
            dbOptions = SqliteInMemory.CreateOptions<ISTSpacePlanningContext>();
            context = new ISTSpacePlanningContext(dbOptions);
            spacePlanningUnitWork = new UnitOfWork(context);
            context.Database.EnsureCreated();
        }

        [TestMethod]
        public void ShouldInsertUserWhenDBContextIsValid()
        {
            testUser = CreateUser();
            spacePlanningUnitWork.UserRepository.Add(testUser);
            spacePlanningUnitWork.Save();
            Assert.IsTrue(spacePlanningUnitWork.UserRepository.GetById(testUser.UserId) != null);
        }

        [TestMethod]
        public void ShouldDeleteUserWhenDBContextIsValid()
        {
            testUser = CreateUser();
            spacePlanningUnitWork.UserRepository.Add(testUser);
            spacePlanningUnitWork.Save();
            Assert.IsTrue(spacePlanningUnitWork.UserRepository.GetById(testUser.UserId) != null);
            spacePlanningUnitWork.UserRepository.Delete(testUser);
            spacePlanningUnitWork.Save();
            Assert.IsTrue(spacePlanningUnitWork.UserRepository.GetById(testUser.UserId) == null);
        }

        [TestMethod]
        public void ShouldUpdateUserWhenDBContextIsValid()
        {
            testUser = CreateUser();
            string userName = "testUser1v2";
            spacePlanningUnitWork.UserRepository.Add(this.testUser);
            spacePlanningUnitWork.Save();
            this.testUser = spacePlanningUnitWork.UserRepository.GetById(this.testUser.UserId);
            this.testUser.Username = userName;
            spacePlanningUnitWork.Save();
            Assert.AreEqual(userName, spacePlanningUnitWork.UserRepository.GetById(this.testUser.UserId).Username);
        }
        [TestMethod]
        public void ShouldGetUserWhenDBContextIsValid()
        {
            testUser = CreateUser();
            spacePlanningUnitWork.UserRepository.Add(testUser);
            spacePlanningUnitWork.Save();
            testUser = spacePlanningUnitWork.UserRepository.GetById(testUser.UserId);
            Assert.IsNotNull(testUser);
        }

        [TestCleanup]
        public void CleanUp()
        {
            context.Dispose();
            testUser = null;
        }

        private User CreateUser()
        {
            testUser = new User()
            {
                UserId = Guid.NewGuid(),
                Username = "testUser1",
                Password = "Test-User1"
            };
            return testUser;
        }

    }
}
