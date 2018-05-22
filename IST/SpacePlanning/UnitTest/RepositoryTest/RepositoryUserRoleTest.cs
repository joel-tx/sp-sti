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
    public class RepositoryUserRoleTest
    {
        private UnitOfWork spacePlanningUnitWork;
        private DbContextOptions<ISTSpacePlanningContext> dbOptions;
        private ISTSpacePlanningContext context;
        private UserRole userRole;

        [TestInitialize]
        public void SetUp()
        {
            dbOptions = SqliteInMemory.CreateOptions<ISTSpacePlanningContext>();
            context = new ISTSpacePlanningContext(dbOptions);
            spacePlanningUnitWork = new UnitOfWork(context);
            context.Database.EnsureCreated();
        }

        [TestMethod]
        public void ShouldInsertUserRoleWhenDBContextIsValid()
        {
            userRole = CreateUserRole();
            spacePlanningUnitWork.UserRoleRepository.Add(userRole);
            spacePlanningUnitWork.Save();
            Assert.IsTrue(spacePlanningUnitWork.UserRoleRepository.GetById(userRole.UserId, userRole.RoleId) != null);
        }

        [TestMethod]
        public void ShouldDeleteUserRoleWhenDBContextIsValid()
        {
            userRole = CreateUserRole();
            spacePlanningUnitWork.UserRoleRepository.Add(userRole);
            spacePlanningUnitWork.Save();
            Assert.IsTrue(spacePlanningUnitWork.UserRoleRepository.GetById(userRole.UserId, userRole.RoleId) != null);
            spacePlanningUnitWork.UserRoleRepository.Delete(userRole);
            spacePlanningUnitWork.Save();
            Assert.IsTrue(spacePlanningUnitWork.UserRoleRepository.GetById(userRole.UserId, userRole.RoleId) == null);
        }

        [TestMethod]
        public void ShouldGetUserRoleWhenDBContextIsValid()
        {
            userRole = CreateUserRole();
            spacePlanningUnitWork.UserRoleRepository.Add(userRole);
            spacePlanningUnitWork.Save();
            userRole = spacePlanningUnitWork.UserRoleRepository.GetById(userRole.UserId, userRole.RoleId);
            Assert.IsNotNull(userRole);
        }

        [TestCleanup]
        public void CleanUp()
        {
            context.Dispose();
            userRole = null;
        }

        private UserRole CreateUserRole()
        {
            User testUser = new User()
            {
                UserId = Guid.NewGuid(),
                Username = "testUser1",
                Password = "Test-User1"
            };

            spacePlanningUnitWork.Save();
            spacePlanningUnitWork.UserRepository.Add(testUser);

            Role testRole = new Role()
            {
                RoleId = Guid.NewGuid(),
                Name = "testRole1",
                Description = "Test-description-1"
            };

            spacePlanningUnitWork.Save();
            spacePlanningUnitWork.RoleRepository.Add(testRole);

            userRole = new UserRole()
            {
                UserId = testUser.UserId,
                RoleId = testRole.RoleId,
            };

            userRole.User = testUser;
            userRole.Role = testRole;

            return userRole;
        }

    }
}
