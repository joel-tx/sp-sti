using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class PermissionRepositoryUnitTest : AbstractRepositoryTest
    {
        #region Test crud...
        [TestMethod]
        public void ShouldInsertWhenPermissionRepositoryIsValid()
        {
            var entity = FactoryPermission.RandomCreate();
            _spacePlanningUnitOfWork.PermissionRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.PermissionRepository.GetById(entity.PermissionId);

            Assert.IsTrue(retrived.Equals(entity));
        }

        [TestMethod]
        public void ShouldUpdateWhenPermissionRepositoryIsValid()
        {
            var entity = FactoryPermission.RandomCreate();
            _spacePlanningUnitOfWork.PermissionRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.PermissionRepository.Update(entity);
            var retrived = _spacePlanningUnitOfWork.PermissionRepository.GetById(entity.PermissionId);

            Assert.IsTrue(entity.Equals(retrived));
        }

        [TestMethod]
        public void ShouldDeleteWhenPermissionRepositoryIsValid()
        {
            var entity = FactoryPermission.RandomCreate();
            _spacePlanningUnitOfWork.PermissionRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.PermissionRepository.Delete(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.PermissionRepository.GetById(entity.PermissionId);

            Assert.IsNull(retrived);
        }
        #endregion
    }
}
