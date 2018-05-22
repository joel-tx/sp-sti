using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class OperationPermissionRepositoryUnitTest : AbstractRepositoryTest
    {
        #region Test crud...
        [TestMethod]
        public void ShouldInsertWhenOperationPermissionRepositoryIsValid()
        {
            var entity = FactoryOperationPermission.RandomCreate();
            _spacePlanningUnitOfWork.OperationPermissionRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.OperationPermissionRepository.GetById(entity.OperationId, entity.PermissionId);

            Assert.IsTrue(retrived.Equals(entity));
        }

        [TestMethod]
        public void ShouldUpdateWhenOperationPermissionRepositoryIsValid()
        {
            var entity = FactoryOperationPermission.RandomCreate();
            _spacePlanningUnitOfWork.OperationPermissionRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            _spacePlanningUnitOfWork.OperationPermissionRepository.Update(entity);
            var retrived = _spacePlanningUnitOfWork.OperationPermissionRepository.GetById(entity.OperationId, entity.PermissionId);
            Assert.IsTrue(entity.Equals(retrived));
        }

        [TestMethod]
        public void ShoultDeleteWhenOperationPermissionRepositoryIsValid()
        {
            var entity = FactoryOperationPermission.RandomCreate();
            _spacePlanningUnitOfWork.OperationPermissionRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.OperationPermissionRepository.Delete(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.OperationPermissionRepository.GetById(entity.OperationId, entity.PermissionId);

            Assert.IsNull(retrived);
        }
        #endregion
    }
}
