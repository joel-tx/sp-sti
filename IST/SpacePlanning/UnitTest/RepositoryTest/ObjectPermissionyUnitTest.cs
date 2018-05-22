using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class ObjectPermissionRepositoryUnitTest : AbstractRepositoryTest
    {
        #region Test crud...
        [TestMethod]
        public void ShouldInsertWhenObjectPermissionRepositoryIsValid()
        {
            var entity = FactoryObjectPermission.RandomCreate();
            _spacePlanningUnitOfWork.ObjectPermissionRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.ObjectPermissionRepository.GetById(entity.ObjectId, entity.PermissionId);

            Assert.IsTrue(retrived.Equals(entity));
        }

        [TestMethod]
        public void ShouldUpdateWhenObjectPermissionRepositoryIsValid()
        {
            var entity = FactoryObjectPermission.RandomCreate();
            _spacePlanningUnitOfWork.ObjectPermissionRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            _spacePlanningUnitOfWork.ObjectPermissionRepository.Update(entity);
            var retrived = _spacePlanningUnitOfWork.ObjectPermissionRepository.GetById(entity.ObjectId, entity.PermissionId);
            Assert.IsTrue(entity.Equals(retrived));
        }

        [TestMethod]
        public void ShoultDeleteWhenObjectPermissionRepositoryIsValid()
        {
            var entity = FactoryObjectPermission.RandomCreate();
            _spacePlanningUnitOfWork.ObjectPermissionRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.ObjectPermissionRepository.Delete(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.ObjectPermissionRepository.GetById(entity.ObjectId, entity.PermissionId);

            Assert.IsNull(retrived);
        }
        #endregion
    }
}