using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class RoleRepositoryUnitTest : AbstractRepositoryTest
    {
        #region Test crud...
        [TestMethod]
        public void ShouldInsertWhenRoleRepositoryIsValid()
        {
            var entity = FactoryRole.RandomCreate();
            _spacePlanningUnitOfWork.RoleRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.RoleRepository.GetById(entity.RoleId);

            Assert.IsTrue(retrived.Equals(entity));
        }

        [TestMethod]
        public void ShouldUpdateWhenRoleRepositoryIsValid()
        {
            var entity = FactoryRole.RandomCreate();
            _spacePlanningUnitOfWork.RoleRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.RoleRepository.Update(entity);
            var retrived = _spacePlanningUnitOfWork.RoleRepository.GetById(entity.RoleId);

            Assert.IsTrue(entity.Equals(retrived));
        }

        [TestMethod]
        public void ShouldDeleteWhenRoleRepositoryIsValid()
        {
            var entity = FactoryRole.RandomCreate();
            _spacePlanningUnitOfWork.RoleRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.RoleRepository.Delete(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.RoleRepository.GetById(entity.RoleId);

            Assert.IsNull(retrived);
        }
        #endregion
    }
}