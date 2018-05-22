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
    public class RepositoryRolePermissionTest
    {
        private UnitOfWork spacePlanningUnitWork;
        private DbContextOptions<ISTSpacePlanningContext> dbOptions;
        private ISTSpacePlanningContext context;
        private RolePermission rolePermission;

        [TestInitialize]
        public void SetUp()
        {
            dbOptions = SqliteInMemory.CreateOptions<ISTSpacePlanningContext>();
            context = new ISTSpacePlanningContext(dbOptions);
            spacePlanningUnitWork = new UnitOfWork(context);
            context.Database.EnsureCreated();
        }

        [TestMethod]
        public void ShouldInsertRolePermissionWhenDBContextIsValid()
        {
            rolePermission = CreateRolePermission();
            spacePlanningUnitWork.RolePermissionRepository.Add(rolePermission);
            spacePlanningUnitWork.Save();
            Assert.IsTrue(spacePlanningUnitWork.RolePermissionRepository.GetById(rolePermission.RoleId, rolePermission.PermissionId) != null);
        }

        [TestMethod]
        public void ShouldDeleteRolePermissionWhenDBContextIsValid()
        {
            rolePermission = CreateRolePermission();
            spacePlanningUnitWork.RolePermissionRepository.Add(rolePermission);
            spacePlanningUnitWork.Save();
            Assert.IsTrue(spacePlanningUnitWork.RolePermissionRepository.GetById(rolePermission.RoleId, rolePermission.PermissionId) != null);
            spacePlanningUnitWork.RolePermissionRepository.Delete(rolePermission);
            spacePlanningUnitWork.Save();
            Assert.IsTrue(spacePlanningUnitWork.RolePermissionRepository.GetById(rolePermission.RoleId, rolePermission.PermissionId) == null);
        }

        [TestMethod]
        public void ShouldGetRolePermissionWhenDBContextIsValid()
        {
            rolePermission = CreateRolePermission();
            spacePlanningUnitWork.RolePermissionRepository.Add(rolePermission);
            spacePlanningUnitWork.Save();
            rolePermission = spacePlanningUnitWork.RolePermissionRepository.GetById(rolePermission.RoleId, rolePermission.PermissionId);
            Assert.IsNotNull(rolePermission);
        }

        [TestCleanup]
        public void CleanUp()
        {
            context.Dispose();
            rolePermission = null;
        }

        private RolePermission CreateRolePermission()
        {
            Role testRole = new Role()
            {
                RoleId = Guid.NewGuid(),
                Name = "testRole1",
                Description = "Test-description-1"
            };

            spacePlanningUnitWork.Save();
            spacePlanningUnitWork.RoleRepository.Add(testRole);

            Permission terPermission = new Permission()
            {
                PermissionId = Guid.NewGuid(),
                Name = "permission1",
                Description = "description1"
            };

            rolePermission = new RolePermission()
            {
                RoleId = testRole.RoleId,
                PermissionId = terPermission.PermissionId,
                Role = testRole,
                Permission = terPermission
            };
            return rolePermission;
        }

    }
}
