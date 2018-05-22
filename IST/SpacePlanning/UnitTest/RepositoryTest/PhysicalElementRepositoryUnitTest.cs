using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IST.SpacePlanning.UnitTest.RepositoryTest
{
    [TestClass]
    public class PhysicalElementRepositoryUnitTest : AbstractRepositoryTest 
    {
        #region Test crud...
        [TestMethod]
        public void ShouldInsertWhenPhysicalElementRepositoryIsValid()
        {
            var entity = FactoryPhysicalElement.RandomCreate();
            _spacePlanningUnitOfWork.PhysicalElementRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.PhysicalElementRepository.GetById(entity.PhysicalElementId);

            Assert.IsTrue(retrived.Equals(entity));
        }

        [TestMethod]
        public void ShouldUpdateWhenPhysicalElementRepositoryIsValid()
        {
            var entity = FactoryPhysicalElement.RandomCreate();
            _spacePlanningUnitOfWork.PhysicalElementRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();
            _spacePlanningUnitOfWork.PhysicalElementRepository.Update(entity);
            var retrived = _spacePlanningUnitOfWork.PhysicalElementRepository.GetById(entity.PhysicalElementId);

            Assert.IsTrue(entity.Equals(retrived));
        }

        [TestMethod]
        public void ShoultDeleteWhenPhysicalElementRepositoryIsValid()
        {
            var entity = FactoryPhysicalElement.RandomCreate();
            _spacePlanningUnitOfWork.PhysicalElementRepository.Add(entity);
            _spacePlanningUnitOfWork.Save();

            _spacePlanningUnitOfWork.PhysicalElementRepository.Delete(entity);
            _spacePlanningUnitOfWork.Save();
            var retrived = _spacePlanningUnitOfWork.PhysicalElementRepository.GetById(entity.PhysicalElementId);

            Assert.IsNull(retrived);
        }
        #endregion
    }
}