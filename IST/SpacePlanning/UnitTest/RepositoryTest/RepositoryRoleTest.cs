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
    public class RepositoryRoleTest
    {
        private UnitOfWork spacePlanningUnitWork;
        private DbContextOptions<ISTSpacePlanningContext> dbOptions;
        private ISTSpacePlanningContext context;
        private Role testRole;

        [TestInitialize]
        public void SetUp()
        {
            dbOptions = SqliteInMemory.CreateOptions<ISTSpacePlanningContext>();
            context = new ISTSpacePlanningContext(dbOptions);
            spacePlanningUnitWork = new UnitOfWork(context);
            context.Database.EnsureCreated();
        }

        [TestMethod]
        public void ShouldInsertRoleWhenDBContextIsValid()
        {
            testRole = CreateRole();
            spacePlanningUnitWork.RoleRepository.Add(testRole);
            spacePlanningUnitWork.Save();
            Assert.IsTrue(spacePlanningUnitWork.RoleRepository.GetById(testRole.RoleId) != null);
        }

        [TestMethod]
        public void ShouldDeleteRoleWhenDBContextIsValid()
        {
            testRole = CreateRole();
            spacePlanningUnitWork.RoleRepository.Add(testRole);
            spacePlanningUnitWork.Save();
            Assert.IsTrue(spacePlanningUnitWork.RoleRepository.GetById(testRole.RoleId) != null);
            spacePlanningUnitWork.RoleRepository.Delete(testRole);
            spacePlanningUnitWork.Save();
            Assert.IsTrue(spacePlanningUnitWork.RoleRepository.GetById(testRole.RoleId) == null);
        }

        [TestMethod]
        public void ShouldUpdateRoleWhenDBContextIsValid()
        {
            testRole = CreateRole();
            string RoleName = "testRole1v2";
            spacePlanningUnitWork.RoleRepository.Add(this.testRole);
            spacePlanningUnitWork.Save();
            this.testRole = spacePlanningUnitWork.RoleRepository.GetById(this.testRole.RoleId);
            this.testRole.Name = RoleName;
            spacePlanningUnitWork.Save();
            Assert.AreEqual(RoleName, spacePlanningUnitWork.RoleRepository.GetById(this.testRole.RoleId).Name);
        }

        [TestMethod]
        public void ShouldGetRoleWhenDBContextIsValid()
        {
            testRole = CreateRole();
            spacePlanningUnitWork.RoleRepository.Add(testRole);
            spacePlanningUnitWork.Save();
            testRole = spacePlanningUnitWork.RoleRepository.GetById(testRole.RoleId);
            Assert.IsNotNull(testRole);
        }

        [TestCleanup]
        public void CleanUp()
        {
            context.Dispose();
            testRole = null;
        }

        private Role CreateRole()
        {
            testRole = new Role()
            {
                RoleId = Guid.NewGuid(),
                Name = "testRole1",
                Description = "Test-description-1"
            };
            return testRole;
        }

    }
}
