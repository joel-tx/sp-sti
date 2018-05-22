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
    public class RepositoryPermissionTest
    {
        private UnitOfWork spacePlanningUnitWork;
        private DbContextOptions<ISTSpacePlanningContext> dbOptions;
        private ISTSpacePlanningContext context;
        private Permission testPermission;

        [TestInitialize]
        public void SetUp()
        {
            dbOptions = SqliteInMemory.CreateOptions<ISTSpacePlanningContext>();
            context = new ISTSpacePlanningContext(dbOptions);
            spacePlanningUnitWork = new UnitOfWork(context);
            context.Database.EnsureCreated();
        }

        [TestMethod]
        public void ShouldInsertPermissionWhenDBContextIsValid()
        {
            testPermission = CreatePermission();
            spacePlanningUnitWork.PermissionRepository.Add(testPermission);
            spacePlanningUnitWork.Save();
            Assert.IsTrue(spacePlanningUnitWork.PermissionRepository.GetById(testPermission.PermissionId) != null);
        }

        [TestMethod]
        public void ShouldDeletePermissionWhenDBContextIsValid()
        {
            testPermission = CreatePermission();
            spacePlanningUnitWork.PermissionRepository.Add(testPermission);
            spacePlanningUnitWork.Save();
            Assert.IsTrue(spacePlanningUnitWork.PermissionRepository.GetById(testPermission.PermissionId) != null);
            spacePlanningUnitWork.PermissionRepository.Delete(testPermission);
            spacePlanningUnitWork.Save();
            Assert.IsTrue(spacePlanningUnitWork.PermissionRepository.GetById(testPermission.PermissionId) == null);
        }

        [TestMethod]
        public void ShouldUpdatePermissionWhenDBContextIsValid()
        {
            testPermission = CreatePermission();
            string namePermission = "permission1v2";
            spacePlanningUnitWork.PermissionRepository.Add(this.testPermission);
            spacePlanningUnitWork.Save();
            this.testPermission = spacePlanningUnitWork.PermissionRepository.GetById(this.testPermission.PermissionId);
            this.testPermission.Name = namePermission;
            spacePlanningUnitWork.Save();
            Assert.AreEqual(namePermission, spacePlanningUnitWork.PermissionRepository.GetById(this.testPermission.PermissionId).Name);
        }
        [TestMethod]
        public void ShouldGetPermissionWhenDBContextIsValid()
        {
            testPermission = CreatePermission();
            spacePlanningUnitWork.PermissionRepository.Add(testPermission);
            spacePlanningUnitWork.Save();
            testPermission = spacePlanningUnitWork.PermissionRepository.GetById(testPermission.PermissionId);
            Assert.IsNotNull(testPermission);
        }

        [TestCleanup]
        public void CleanUp()
        {
            context.Dispose();
            testPermission = null;
        }

        private Permission CreatePermission()
        {
            testPermission = new Permission()
            {
                PermissionId = Guid.NewGuid(),
                Name = "permission1",
                Description = "description1"
            };
            return testPermission;
        }

    }
}
