using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class RolePermissionRepositoryUnitTest : AbstractRepositoryTest
    {
        #region Test crud...
        [TestMethod]
        public void ShouldInsertWhenRolePermissionRepositoryIsValid()
        {
            var entity = FactoryRolePermission.RandomCreate();
            _spacePlanningUnitOfWork.RolePermissionRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.RolePermissionRepository.GetById(entity.RoleId, entity.PermissionId);

            Assert.IsTrue(retrived.Equals(entity));
        }

        [TestMethod]
        public void ShouldUpdateWhenRolePermissionRepositoryIsValid()
        {
            var entity = FactoryRolePermission.RandomCreate();
            _spacePlanningUnitOfWork.RolePermissionRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.RolePermissionRepository.Update(entity);
            var retrived = _spacePlanningUnitOfWork.RolePermissionRepository.GetById(entity.RoleId, entity.PermissionId);

            Assert.IsTrue(entity.Equals(retrived));
        }

        [TestMethod]
        public void ShouldDeleteWhenRolePermissionRepositoryIsValid()
        {
            var entity = FactoryRolePermission.RandomCreate();
            _spacePlanningUnitOfWork.RolePermissionRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.RolePermissionRepository.Delete(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.RolePermissionRepository.GetById(entity.RoleId, entity.PermissionId);

            Assert.IsNull(retrived);
        }
        #endregion
    }
}